using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThePizzaProject.Models;
using ThePizzaProject.Data;
using System.Xml.Linq;

namespace ThePizzaProject.Pages.CreatePizza
{
	public class IndexModel : PageModel
	{
		private readonly ThePizzaProjectContext _context;
		private readonly IHttpContextAccessor _contextAccessor;

		private readonly AccessControl accessControl;
		public readonly FileRepository uploads;

		public IndexModel(ThePizzaProjectContext context, IHttpContextAccessor httpContextAccessor, AccessControl accessControl, FileRepository uploads)
		{
			_context = context;
			this._contextAccessor = httpContextAccessor;
			this.accessControl = accessControl;
			this.uploads = uploads;

		}

		public List<Ingredient> Ingredients { get; set; }

		public string photoUrl { get; set; }

		public List<string> PhotoURLs { get; set; } = new List<string>();

		public string Name { get; set; }

		[BindProperty]
		public IFormFile photo { get; set; }

		public void OnGet()
		{
			Ingredients = _context.Ingredients.ToList();
			photo = null;
		}

		public IActionResult OnPost(int[] ingredients, string pizzaName, IFormFile? photo)
		{
			var accessControl = new AccessControl(_context, _contextAccessor);
			int loggedUser = accessControl.LoggedInAccountID;

			if (string.IsNullOrEmpty(pizzaName))
			{
				ModelState.AddModelError("Name", "Name is required.");
			}

			if (photo == null || photo.Length == 0)
			{
				ModelState.AddModelError("photo", "Please choose a photo.");
			}

		

			if (!ModelState.IsValid)
			{
				OnGet();
				return Page();
			}

			var newPizza = new Pizza
			{
				AccountID = loggedUser,
				PizzaName = pizzaName,
				PizzaIngredients = new List<PizzaIngredient>()

			};

			_context.Pizzas.Add(newPizza);

			foreach (var i in ingredients)
			{
				var ingredientData = _context.Ingredients.Find(i);

				newPizza.PizzaIngredients.Add(new PizzaIngredient
				{

					Ingredient = ingredientData
				});
			}

			_context.SaveChanges();

			if (photo != null)
			{
				UploadPhoto(photo, newPizza);
			}

			return RedirectToPage();
		}

		public async Task<IActionResult> UploadPhoto(IFormFile? photo, Pizza newPizza)
		{
			string userFolderPath = Path.Combine(
			uploads.FolderPath,
			accessControl.LoggedInAccountID.ToString()
		);
			string updatedFileName = newPizza.PizzaID.ToString();
			string path = Path.Combine(
				accessControl.LoggedInAccountID.ToString(),
				  updatedFileName + ".jpeg"
			);

			await uploads.SaveFileAsync(photo, path);

			string[] files = Directory.GetFiles(userFolderPath);
			foreach (string file in files)
			{
				string url = uploads.GetFileURL(file);
				PhotoURLs.Add(url);
			}

			return RedirectToPage();
		}
	}
}