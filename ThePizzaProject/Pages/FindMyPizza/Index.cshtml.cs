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
		private readonly ThePizzaProjectContext _dbContext;

		public IndexModel(ThePizzaProjectContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IList<Pizza> Pizzas { get; set; }

		public void OnGet(string ingredient)
		{
			var query = _dbContext.Pizzas.AsQueryable();

			if (!string.IsNullOrEmpty(ingredient))
			{
				query = query.Where(p => p.PizzaIngredients.Any(i => i.Ingredients.IngredientName.Contains(ingredient)));
			}

			Pizzas = query.Include(p => p.PizzaIngredients).ToList();
		}
	}
}
