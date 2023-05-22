using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThePizzaProject.Data;
using ThePizzaProject.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ThePizzaProject.ViewModels;

namespace ThePizzaProject.Pages.ThePizzaPage
{
    public class IndexModel : PageModel
    {
        private readonly ThePizzaProjectContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public IndexModel(ThePizzaProjectContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            Ingredients = new List<Ingredient>(); // Initialize the Ingredients property
            this._contextAccessor = httpContextAccessor;
        }

        public PizzaViewModel Pizzas { get; set; }
        public CommentPizza commentPizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        


        public void OnGet(int id)
        {
            var myPizza = _context.Pizzas
                .Where(p => p.PizzaID == id)
                .Include(p => p.CommentPizza.Where(cp => cp.Pizza.PizzaID == id))
                .ThenInclude(cp => cp.Comment)
                .ThenInclude(c => c.User)
               
                .Select(p => new Pizza
                {
                    PizzaID = p.PizzaID,
                    PizzaName = p.PizzaName,
                    PizzaIngredients = p.PizzaIngredients
                        .Select(pi => new PizzaIngredient
                        {
                            PizzaIngredientID = pi.PizzaIngredientID,
                            Ingredient = new Ingredient
                            {
                                IngredientID = pi.Ingredient.IngredientID,
                                IngredientName = pi.Ingredient.IngredientName,
                                Category = pi.Ingredient.Category,
                            }
                        }).ToList(),
                    CommentPizza = p.CommentPizza.ToList(),

                    User = p.User,
                    AccountID = p.AccountID
                })
                .FirstOrDefault();

            if (myPizza == null)
            {
                //Error handling i framtiden.
            }

            Pizzas = new PizzaViewModel {
                ID = myPizza.PizzaID,
                Name = myPizza.PizzaName,
                UserName = myPizza.User.Name,
                Comments = myPizza.CommentPizza.Select(c => new CommentViewModel
                {
                    DateTime = c.Comment.DateTime,
                    Comment = c.Comment.CommentText,
                    UserName = c.Comment.User.Name,
                }).ToList(),
                Ingredients = myPizza.PizzaIngredients.Select(i => new IngredientViewModel
                {
                    ID = i.Ingredient.IngredientID,
                    Name = i.Ingredient.IngredientName,
                    Category = i.Ingredient.Category,
                    // TODO: Fixa kaloeriberäkning
                    Kcal = 0
                }).ToList()
            };

            int totalKcal = Pizzas.Ingredients.Sum(i => i.Kcal);

        }

        public void OnPost(string commentText, int id)
        {
            var accessControl = new AccessControl(_context, _contextAccessor);
            int loggedUser = accessControl.LoggedInAccountID;


            Comment newComment = new Comment
            {
                CommentText = commentText,
                DateTime = DateTime.Now,
                CommentPizzas = new List<CommentPizza>
                {
                    new CommentPizza

                    {
                        Pizza = _context.Pizzas.FirstOrDefault(p => p.PizzaID == id)
                    }
                },
                User = _context.Accounts.FirstOrDefault(p => p.AccountID == loggedUser)
             

            };

            _context.Add(newComment);


            //_context.Add(commentUser);
            _context.SaveChanges();

            OnGet(id);

        }
    }
}