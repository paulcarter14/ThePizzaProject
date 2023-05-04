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
		}

		public List<Ingredient> Ingredients { get; set; }
		public List<Pizza> Pizzas { get; set; }

		public void OnGet()
		{
			Ingredients = _context.Ingredients.ToList();
			Pizzas = _context.Pizzas.Include(p => p.PizzaIngredient).ToList();
		}
	}
}
