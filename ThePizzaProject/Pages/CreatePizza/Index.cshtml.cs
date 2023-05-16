using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThePizzaProject.Models; // assuming your Ingredient model is in this namespace
using ThePizzaProject.Data; // assuming your database context is in this namespace

namespace ThePizzaProject.Pages.CreatePizza
{
    public class IndexModel : PageModel
    {
        private readonly ThePizzaProjectContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

		private readonly AccessControl accessControl;
		public readonly FileRepository uploads;

		public IndexModel(ThePizzaProjectContext context , IHttpContextAccessor httpContextAccessor, AccessControl accessControl, FileRepository uploads)
        {
            _context = context;
			this._contextAccessor = httpContextAccessor;
			this.accessControl = accessControl;
			this.uploads = uploads;
		}

        public List<Ingredient> Ingredients { get; set; }

        public void OnGet()
        {
            Ingredients = _context.Ingredients.ToList();


			//Denna koden visar bilderna på sidan. 

			//string[] files = Directory.GetFiles(userFolderPath);
			//foreach (string file in files)
			//{
			//	string url = uploads.GetFileURL(file);
			//	PhotoURLs.Add(url);
			//}

		}

		public IActionResult OnPost(int[] ingredients, string pizzaName, IFormFile ?photo)
		{
            var accessControl = new AccessControl(_context, _contextAccessor);
            int loggedUser = accessControl.LoggedInAccountID;

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


				//_context.Attach(ingredientData);

				newPizza.PizzaIngredients.Add( new PizzaIngredient
				{

					Ingredient = ingredientData
				});

			}
			
			_context.SaveChanges();

			if(photo != null){

				UploadPhoto(photo, newPizza);

			}
			
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> UploadPhoto(IFormFile? photo, Pizza newPizza)
		{
		
			string userFolderPath = Path.Combine(
			uploads.FolderPath,
			accessControl.LoggedInAccountID.ToString()
		);


			Directory.CreateDirectory(userFolderPath);

			string path = Path.Combine(
				accessControl.LoggedInAccountID.ToString(),
				Guid.NewGuid().ToString() + "-" + photo.FileName
			);
			//string fileName = photo +
			await uploads.SaveFileAsync(photo, path);
			return RedirectToPage();
		}
	}
}
