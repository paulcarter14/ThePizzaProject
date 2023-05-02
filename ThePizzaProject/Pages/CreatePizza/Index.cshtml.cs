using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThePizzaProject.Models; // assuming your Ingredient model is in this namespace
using ThePizzaProject.Data; // assuming your database context is in this namespace

namespace ThePizzaProject.Pages.CreatePizza
{
    public class IndexModel : PageModel
    {
        private readonly ThePizzaProjectContext _context;

        public IndexModel(ThePizzaProjectContext context)
        {
            _context = context;
        }

        public List<Ingredient> Ingredients { get; set; }

        public void OnGet()
        {
            Ingredients = _context.Ingredients.ToList();
        }
    }
}
