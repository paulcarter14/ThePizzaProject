using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThePizzaProject.Data;
using ThePizzaProject.Models;

namespace ThePizzaProject.Pages.ThePizzaPage
{
	public class IndexModel : PageModel
	{
		private readonly ThePizzaProjectContext _context;

		public IndexModel(ThePizzaProjectContext context)
		{
			_context = context;
			Ingredients = new List<Ingredient>(); // Initialize the Ingredients property
		}

		public Pizza Pizzas { get; set; }
		public List<Ingredient> Ingredients { get; set; }


		public void OnGet()
		{
			var id = Request.Query["id"];

			var myPizza = _context.Pizzas
	.Where(p => p.PizzaID == id)
	.Select(p => new Pizza
	{
		PizzaID = p.PizzaID,
		PizzaName = p.PizzaName,
		PizzaIngredients = p.PizzaIngredients.Select(pi => new PizzaIngredient
		{
			PizzaIngredientID = pi.PizzaIngredientID,
			Ingredient = new Ingredient
			{
				IngredientID = pi.Ingredient.IngredientID,
				IngredientName = pi.Ingredient.IngredientName,
				Category = pi.Ingredient.Category,
			}
		}).ToList(),
		User = p.User,
		AccountID = p.AccountID
	})
	.SingleOrDefault();

		}

		public void OnPost()
		{

		}
	}
}
