using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

		public void OnGet()
		{
			Pizzas = _context.Pizzas.Include(p => p.PizzaIngredients).ToList();
			Ingredients = _context.Ingredients.ToList(); // Populate the Ingredients property
		}

		public IActionResult OnPost(List<int> unwantedIngredients, bool veggie, List<int> wantedIngredients)
		{
			UnwantedIngredients = unwantedIngredients ?? new List<int>();
			WantedIngredients = wantedIngredients ?? new List<int>();

			try
			{
				// Check if any filters are applied
				if (unwantedIngredients.Count == 0 && !veggie && (wantedIngredients == null || wantedIngredients.Count == 0))
				{
					throw new Exception("Please select at least one filter option.");
				}
				else
				{
					FilteredPizzas = GetFilteredPizzas(unwantedIngredients, veggie, wantedIngredients);
				}
			}
			catch (Exception ex)
			{
				return RedirectToAction("Index");
			}

			return Page();
		}

		//Lägg till en tryCatch som återvänder till sidan.

		private List<Pizza> GetFilteredPizzas(List<int> ?unwantedIngredients, bool veggie, List<int> ?wantedIngredients)
		{
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
							}).ToList(),
						User = p.User,
						AccountID = p.AccountID
					}).ToList();

			// Veggie Warrior checkboxen står över de andra.
			if (veggie)
			{
				pizzasWithIngredients = pizzasWithIngredients
					.Where(p => !p.PizzaIngredients.Any(i => i.Ingredient.Category == "Protein"))
					.ToList();
			}

			//Filtrerar pizzorna på de övre för att sedan retunera 
			if (wantedIngredients != null && wantedIngredients.Count > 0)
			{
				pizzasWithIngredients = pizzasWithIngredients
					.Where(p => wantedIngredients.All(wi => p.PizzaIngredients.Any(pi => pi.Ingredient.IngredientID == wi)))
					.ToList();
			}

			return pizzasWithIngredients;
		}

		public void SendToPizzaPage()
		{
			RedirectToAction("ThePizzaPage.cshtml");
		}
	}
}
