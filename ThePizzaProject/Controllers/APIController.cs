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
            Pizza pizza = null;
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
                    Ingredients = p.PizzaIngredients.Select(i => i.Ingredient.IngredientName).ToList()
                })
                .ToList();

                //Slumpar en pizza
                var random = new Random();
                var randomPizza = matchingPizzas[random.Next(matchingPizzas.Count)];


                returnPizza.Name = randomPizza.Name;
                returnPizza.Ingredients = randomPizza.Ingredients;

            }
            else if (categoryname == "Meat")
            {
                var matchingPizzas = _context.Pizzas
                .Where(p => p.PizzaIngredients
                    .Any(i => i.Ingredient.Category == categoryname))
                .Select(p => new
                {
                    Name = p.PizzaName,
                    Ingredients = p.PizzaIngredients.Select(i => i.Ingredient.IngredientName).ToList()
                })
                .ToList();

                //Slumpar en pizza
                var random = new Random();
                var randomPizza = matchingPizzas[random.Next(matchingPizzas.Count)];


                returnPizza.Name = randomPizza.Name;
                returnPizza.Ingredients = randomPizza.Ingredients;
            }

            else if (categoryname == "Fish")
            {
                var matchingPizzas = _context.Pizzas
                .Where(p => p.PizzaIngredients
                    .Any(i => i.Ingredient.Category == categoryname))
                .Select(p => new
                {
                    Name = p.PizzaName,
                    Ingredients = p.PizzaIngredients.Select(i => i.Ingredient.IngredientName).ToList()
                })
                .ToList();

                //Slumpar en pizza
                var random = new Random();
                var randomPizza = matchingPizzas[random.Next(matchingPizzas.Count)];

                returnPizza.Name = randomPizza.Name;
                returnPizza.Ingredients = randomPizza.Ingredients;
            }


            else if (categoryname == "Vegetarian")
            {
                var matchingPizzas = _context.Pizzas
                .Where(p => p.PizzaIngredients
                    .All(i => i.Ingredient.Category != "Chicken" && i.Ingredient.Category != "Meat" && i.Ingredient.Category != "Fish"))
                .Select(p => new
                {
                    Name = p.PizzaName,
                    Ingredients = p.PizzaIngredients.Select(i => i.Ingredient.IngredientName).ToList()
                })
                .ToList();

                var random = new Random();
                var randomPizza = matchingPizzas[random.Next(matchingPizzas.Count)];

                returnPizza.Name = randomPizza.Name;
                returnPizza.Ingredients = randomPizza.Ingredients;
            }



            //Retunera Bild, Namn och LI med ingredienser.
            return Ok(returnPizza);
        }

        [HttpGet("pizza-count")]
        public async Task<ActionResult<int>> GetPizzaCount()
        {
            // Retrieve the count of all Pizza records in the database
            int count = await _context.Pizzas.CountAsync();

            // Return the count
            return Ok(count);
        }
    }
}



