using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ThePizzaProject.Data;
using ThePizzaProject.Models;

namespace ThePizzaProject.Pages.FindMyPizza
{
	public class IndexModel : PageModel
	{
		private readonly ThePizzaProjectContext _context;

		public IndexModel(ThePizzaProjectContext context)
		{
			_context = context;
			Ingredients = new List<Ingredient>(); // Initialize the Ingredients property
		}

		public List<Ingredient> Ingredients { get; set; }
		public List<Pizza> Pizzas { get; set; }
		public List<int> SelectedIngredients { get; set; }
		public List<Pizza> FilteredPizzas { get; set; }

		public void OnGet()
		{
			Pizzas = _context.Pizzas.Include(p => p.PizzaIngredients).ToList();
			Ingredients = _context.Ingredients.ToList(); // Populate the Ingredients property
		}

		public IActionResult OnPost(List<int> ingredients)
		{
			SelectedIngredients = ingredients;
			FilteredPizzas = GetFilteredPizzas(SelectedIngredients);

			return Page();
		}

		private List<Pizza> GetFilteredPizzas(List<int> selectedIngredients)
		{


			List<Pizza> pizzasWithIngredients = (
				from p in _context.Pizzas
				where !p.PizzaIngredients.Any(pi => selectedIngredients.Contains(pi.Ingredient.IngredientID))

				select new Pizza
				{
					PizzaID = p.PizzaID,
					PizzaName = p.PizzaName,
					PizzaIngredients = (
						from pi in p.PizzaIngredients
						select new PizzaIngredient
						{
							PizzaIngredientID = pi.PizzaIngredientID,
							Pizza = null,
							Ingredient = new Ingredient
							{
								IngredientID = pi.Ingredient.IngredientID,
								IngredientName = pi.Ingredient.IngredientName,
								Category = pi.Ingredient.Category,
								PizzaIngredients = null
							}
						}
						).ToList(),
					User = p.User,
					AccountID = p.AccountID
				}).ToList();

			// Filter the pizzas based on the selected ingredients
			//var filteredPizzas = pizzas.Where(pizza =>
			//	!pizza.PizzaIngredients.Any(pi => selectedIngredients.Contains(pi.PizzaIngredientID)))
			//	.ToList();

			return pizzasWithIngredients.ToList();
		}
	}
}
