using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePizzaProject.Data;
using ThePizzaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ThePizzaProject.Controllers
{
    [Route("/api")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ThePizzaProjectContext database;

        public APIController(ThePizzaProjectContext database)
        {
            this.database = database;
        }

        //[HttpGet]
        //public async Task<ActionResult<Pizza>> GetPizzaByCategory(string categoryname)
        //{
        //    Pizza pizza = null;

        //    if (categoryname == "Chicken")
        //    {
        //        pizza = await database.Pizzas
        //            .Include(p => p.PizzaIngredients)
        //            .FirstOrDefaultAsync(p => p.PizzaIngredients.Any(i => i.Ingredient.Category == "Chicken"));
        //    }
        //    else if (categoryname == "Meat")
        //    {
        //        pizza = await database.Pizzas
        //            .Include(p => p.PizzaIngredients)
        //            .FirstOrDefaultAsync(p => p.PizzaIngredients.Any(i => i.Ingredient.Category == "Meat"));
        //    }
        //    else if (categoryname.ToLower() == "Fish")
        //    {
        //        pizza = await database.Pizzas
        //            .Include(p => p.PizzaIngredients)
        //            .FirstOrDefaultAsync(p => p.PizzaIngredients.Any(i => i.Ingredient.Category == "Fish"));
        //    }
        //    else if (categoryname.ToLower() == "Vegeterian")
        //    {
        //        pizza = await database.Pizzas
        //            .Include(p => p.PizzaIngredients)
        //            .FirstOrDefaultAsync(p => p.PizzaIngredients.All(i => i.Ingredient.Category != "Chicken" && i.Ingredient.Category != "Meat" && i.Ingredient.Category != "Fish"));
        //    }

        //    else if (categoryname.ToLower() == "Dessert")
        //    {
        //        //skapa en pizza
        //    }

        //    if (pizza == null)
        //    {
        //        return NotFound();
        //    }

        //    //Retunera Bild, Namn och LI med ingredienser.
        //    return pizza;
        //}
    }
}



