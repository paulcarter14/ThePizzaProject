using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
			var pizzas = _context.Pizzas.Include(p => p.PizzaIngredients).ToList();

			// Filter the pizzas based on the selected ingredients
			var filteredPizzas = pizzas.Where(pizza =>
				!pizza.PizzaIngredients.Any(pi => selectedIngredients.Contains(pi.PizzaIngredientID)))
				.ToList();

			return filteredPizzas;
		}
	}
}
