using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePizzaProject.Data;
using ThePizzaProject.Models;

namespace ThePizzaProject.Controllers
{
	public class PizzaController : Controller
	{
		private readonly Data.ThePizzaProjectContext _dbContext;

		public PizzaController(Data.ThePizzaProjectContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index(string ingredient)
		{
			var pizzas = _dbContext.Pizzas.ToList();

			//if (!string.IsNullOrEmpty(ingredient))
			//{
			//	pizzas = pizzas.Where(p => p.PizzaIngredients.Any(i => i.Ingredients.IngredientName.Contains(ingredient))).ToList();
			//}

			return View(pizzas);
		}

	}
}