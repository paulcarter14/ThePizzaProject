﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;
using ThePizzaProject.Data;
using ThePizzaProject.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = "Google";
})
.AddCookie(options =>
{
	// When a user logs in to Google for the first time, create a local account for that user in our database.
	options.Events.OnValidatePrincipal += async context =>
	{
		var serviceProvider = context.HttpContext.RequestServices;
		using var db = new ThePizzaProjectContext(serviceProvider.GetRequiredService<DbContextOptions<ThePizzaProjectContext>>());

		string subject = context.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
		string issuer = context.Principal.FindFirst(ClaimTypes.NameIdentifier).Issuer;
		string name = context.Principal.FindFirst(ClaimTypes.Name).Value;

		var account = db.Accounts
			.FirstOrDefault(p => p.OpenIDIssuer == issuer && p.OpenIDSubject == subject);

		if (account == null)
		{
			account = new Account
			{
				OpenIDIssuer = issuer,
				OpenIDSubject = subject,
				Name = name
			};
			db.Accounts.Add(account);
		}
		else
		{
			// If the account already exists, just update the name in case it has changed.
			account.Name = name;
		}

		await db.SaveChangesAsync();
	};
})
.AddOpenIdConnect("Google", options =>
{
	options.Authority = "https://accounts.google.com";
	/*
    These two values (client ID and client secret) must be created in the Google Cloud Platform Console:
    https://support.google.com/cloud/answer/6158849?hl=en
    They must then be added to the project's "user secrets": right-click the project in Visual Studio and select "Manage User Secrets" and write the following JSON:
    {
       "Authentication": {
           "Google": {
               "ClientId": "...",
               "ClientSecret": "..."
           }
       }
    }
    */
	options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
	options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
	options.ResponseType = OpenIdConnectResponseType.Code;
	options.CallbackPath = "/signin-oidc-google";
	options.Scope.Add("openid");
	options.Scope.Add("profile");
	options.Scope.Add("email");
	options.SaveTokens = true;
	options.GetClaimsFromUserInfoEndpoint = true;
});

builder.Services.AddAuthorization(options =>
{
	options.FallbackPolicy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ThePizzaProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ThePizzaProjectContext") ?? throw new InvalidOperationException("Connection string 'ThePizzaProjectContext' not found.")));
builder.Services.AddDbContext<ThePizzaProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AccessControl>();

// Steg 2 för att ladda upp bilder.
builder.Services.AddSingleton<FileRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
	//app.UseSwagger();
	//app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Steg 1 för att ladda upp bilder.
Directory.CreateDirectory(builder.Configuration["Uploads:FolderPath"]);
app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		Path.Combine(builder.Environment.ContentRootPath, builder.Configuration["Uploads:FolderPath"])
	),
	RequestPath = builder.Configuration["Uploads:URLPath"]
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapRazorPages();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<ThePizzaProjectContext>();
	SampleData.Create(context);
}

app.Run();