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

        public IndexModel(ThePizzaProjectContext context , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
			this._contextAccessor = httpContextAccessor;
        }

        public List<Ingredient> Ingredients { get; set; }

        public void OnGet()
        {
            Ingredients = _context.Ingredients.ToList();

            
        }

		public IActionResult OnPost(int[] ingredients, string pizzaName)
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
			
			return RedirectToAction("Index");
		}
	}
}
