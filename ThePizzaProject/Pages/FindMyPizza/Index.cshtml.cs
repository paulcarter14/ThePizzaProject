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
		public List<int> UnwantedIngredients { get; set; }
		public List<int> WantedIngredients { get; set; }
		public List<Pizza> FilteredPizzas { get; set; }
		//public bool FilteredNoMeat { get; set; }

		public void OnGet()
		{
			Pizzas = _context.Pizzas.Include(p => p.PizzaIngredients).ToList();
			Ingredients = _context.Ingredients.ToList(); // Populate the Ingredients property
		}

		public IActionResult OnPost(List<int> unwantedIngredients, bool veggie, List<int> wantedIngredients)
		{
			//UnwantedIngredients = unwantedIngredients;
			//WantedIngredients = wantedIngredients;
			FilteredPizzas = GetFilteredPizzas(unwantedIngredients, veggie, wantedIngredients);
			return Page();
		}

		private List<Pizza> GetFilteredPizzas(List<int> unwantedIngredients, bool veggie, List<int> wantedIngredients)
		{
			List<int> filtered = new List<int>();

			if (wantedIngredients != null)
			{
				foreach( var i in wantedIngredients)
				{
					filtered.Add(i);
				}
			}
			List<Pizza> pizzasWithIngredients =
				(
					from p in _context.Pizzas
					where !p.PizzaIngredients.Any(pi => unwantedIngredients.Contains(pi.Ingredient.IngredientID))

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
					}
				).ToList();

			// Filter the pizzas based on the selected ingredients
			//var filteredPizzas = pizzas.Where(pizza =>
			//	!pizza.PizzaIngredients.Any(pi => selectedIngredients.Contains(pi.PizzaIngredientID)))
			//	.ToList();

			var withoutMeat = pizzasWithIngredients.Where(p => p.PizzaIngredients.Any(i => i.Ingredient.Category == "Protein")).ToList();

			foreach (var p in withoutMeat)
			{
				if (veggie)
				{
					pizzasWithIngredients.Remove(p);
				}
			}

			return pizzasWithIngredients.ToList();
		}
	}
}