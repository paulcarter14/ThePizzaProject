using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePizzaProject.Data;
using ThePizzaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol;
using Microsoft.AspNetCore.Authorization;

namespace ThePizzaProject.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("/api")]
    public class APIController : ControllerBase
    {
        private readonly ThePizzaProjectContext _context;

        public APIController(ThePizzaProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Pizza>> GetPizzaByCategory(string categoryname)
        {
            RandomPizza returnPizza = new RandomPizza()
            {

            };

            if (categoryname == "Chicken")
            {
                var matchingPizzas = _context.Pizzas
                .Where(p => p.PizzaIngredients
                    .Any(i => i.Ingredient.Category == categoryname))
                .Select(p => new
                {
                    Name = p.PizzaName,
                    Ingredients = p.PizzaIngredients.Select(i => i.Ingredient.IngredientName).ToList(),
                    pizzaID = p.PizzaID,
                    accountID = p.AccountID,
                })
                .ToList();

                //Slumpar en pizza
                var random = new Random();
                var randomPizza = matchingPizzas[random.Next(matchingPizzas.Count)];

                returnPizza.Name = randomPizza.Name;
                returnPizza.Ingredients = randomPizza.Ingredients;
                returnPizza.photo = "https://pizzaproject3.azurewebsites.net/uploads/" + randomPizza.accountID + "/" + randomPizza.pizzaID + ".jpeg";
            }
            else if (categoryname == "Meat")
            {
                var matchingPizzas = _context.Pizzas
                .Where(p => p.PizzaIngredients
                    .Any(i => i.Ingredient.Category == categoryname))
                .Select(p => new
                {
                    Name = p.PizzaName,
                    Ingredients = p.PizzaIngredients.Select(i => i.Ingredient.IngredientName).ToList(),
                    pizzaID = p.PizzaID,
                    accountID = p.AccountID,
                })
                .ToList();

                //Slumpar en pizza
                var random = new Random();
                var randomPizza = matchingPizzas[random.Next(matchingPizzas.Count)];

                returnPizza.Name = randomPizza.Name;
                returnPizza.Ingredients = randomPizza.Ingredients;
                returnPizza.photo = "https://pizzaproject3.azurewebsites.net/uploads/" + randomPizza.accountID + "/" + randomPizza.pizzaID + ".jpeg";
            }

            else if (categoryname == "Fish")
            {
                var matchingPizzas = _context.Pizzas
                .Where(p => p.PizzaIngredients
                    .Any(i => i.Ingredient.Category == categoryname))
                .Select(p => new
                {
                    Name = p.PizzaName,
                    Ingredients = p.PizzaIngredients.Select(i => i.Ingredient.IngredientName).ToList(),
                    pizzaID = p.PizzaID,
                    accountID = p.AccountID,
                })
                .ToList();

                //Slumpar en pizza
                var random = new Random();
                var randomPizza = matchingPizzas[random.Next(matchingPizzas.Count)];

                returnPizza.Name = randomPizza.Name;
                returnPizza.Ingredients = randomPizza.Ingredients;
                returnPizza.photo = "https://pizzaproject3.azurewebsites.net/uploads/" + randomPizza.accountID + "/" + randomPizza.pizzaID + ".jpeg";
            }

            else if (categoryname == "Vegetarian")
            {
                var matchingPizzas = _context.Pizzas
                .Where(p => p.PizzaIngredients
                    .All(i => i.Ingredient.Category != "Chicken" && i.Ingredient.Category != "Meat" && i.Ingredient.Category != "Fish"))
                .Select(p => new
                {
                    Name = p.PizzaName,
                    Ingredients = p.PizzaIngredients.Select(i => i.Ingredient.IngredientName).ToList(),
                    pizzaID = p.PizzaID,
                    accountID = p.AccountID,
                })
                .ToList();

				//Slumpar en pizza
				var random = new Random();
                var randomPizza = matchingPizzas[random.Next(matchingPizzas.Count)];

                returnPizza.Name = randomPizza.Name;
                returnPizza.Ingredients = randomPizza.Ingredients;
                returnPizza.photo = "https://pizzaproject3.azurewebsites.net/uploads/" + randomPizza.accountID + "/" + randomPizza.pizzaID + ".jpeg";
            }

            else if (categoryname == "Dessert")
            {
                List<string> list = new List<string>()
                {
                    "Sourdough",
                    "Nutella",
                    "Banana",
                    "Strawberry",
                    "Blueberry"
                };
                returnPizza.Name = "Nutella Pizza";
                returnPizza.Ingredients = list;
                returnPizza.photo = "https://res.cloudinary.com/coopsverige/image/upload/h_1200,w_1200/v1674023395/cloud/271734.jpg";
            }
            return Ok(returnPizza);
        }

        [HttpGet("pizza-count")]
		public async Task<ActionResult<List<int>>> GetPizzaIds()
		{
			List<int> pizzaIds = await _context.Pizzas.Select(pizza => pizza.PizzaID).ToListAsync();
            int pizzas = pizzaIds.Count;
			return Ok(pizzas);
		}
	}
}