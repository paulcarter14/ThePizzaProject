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
        private readonly AccessControl accessControl;
        private readonly FileRepository uploads;

        public IndexModel(ThePizzaProjectContext context, IHttpContextAccessor httpContextAccessor, AccessControl accessControl, FileRepository uploads)
        {
            _context = context;
            Ingredients = new List<Ingredient>(); // Initialize the Ingredients property
            this._contextAccessor = httpContextAccessor;
            this.accessControl = accessControl;
            this.uploads = uploads;
        }

        public PizzaViewModel Pizzas { get; set; }
        public CommentPizza commentPizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }
		public int TotalCalories { get; set; }
		public string Text { get; set; }
        public List<string> photoUrl = new List<string>();
        public Pizza PizzaObject { get; set; }
        public int Rating { get; set; }

        public void OnGet(int id)
        {
            var myPizza = _context.Pizzas
                .Where(p => p.PizzaID == id)
                .Include(p => p.CommentPizza.Where(cp => cp.Pizza.PizzaID == id))
                .ThenInclude(cp => cp.Comment)
                .ThenInclude(c => c.User)
                .Include(r => r.RatingPizzas.Where(rp => rp.Pizza.PizzaID == id))

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
                                Calories = pi.Ingredient.Calories
                            }
                        }).ToList(),
                    CommentPizza = p.CommentPizza.ToList(),

                    User = p.User,
                    AccountID = p.AccountID,
                    RatingPizzas = p.RatingPizzas
                    .Select(rp => new RatingPizza
                    {
                        ratingPizzaId = rp.ratingPizzaId,
                        Rating = new Rating
                        {
                            ratingId = rp.Rating.ratingId,
                            ratingValue = rp.Rating.ratingValue,
                        }
                    }).ToList()
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
				UserID = myPizza.AccountID,
				Comments = myPizza.CommentPizza.Select(c => new CommentViewModel
                {
                    DateTime = c.Comment.DateTime,
                    Comment = c.Comment.CommentText,
                    UserName = c.Comment.User.Name
                }).ToList(),
                Ingredients = myPizza.PizzaIngredients.Select(i => new IngredientViewModel
                {
                    ID = i.Ingredient.IngredientID,
                    Name = i.Ingredient.IngredientName,
                    Category = i.Ingredient.Category,
                    Kcal = i.Ingredient.Calories
                }).ToList()
            };

            GetPhotos();
			foreach (var ingredient in Pizzas.Ingredients)
			{
				Console.WriteLine("Ingredient: " + ingredient.Name + ", Calories: " + ingredient.Kcal);
			}

			TotalCalories = Pizzas.Ingredients.Sum(i => i.Kcal);

            if(myPizza.RatingPizzas.Count == 0)
            {
                RedirectToPage();
            }
            else
            {
				var x = myPizza.RatingPizzas.Select(rp => rp.Rating.ratingValue).Average();

				Math.Round(x);

				int roundedValue = Convert.ToInt32(x);

				Rating = roundedValue;
			}	
		}

		public IActionResult UpdateRatingPizza(int pizzaId, int rating)
		{
			var accessControl = new AccessControl(_context, _contextAccessor);
			int loggedUser = accessControl.LoggedInAccountID;
			var pizza = _context.Pizzas.FirstOrDefault(p => p.PizzaID == pizzaId);

			Rating newRating = new Rating
			{
				ratingValue = rating,
				RatingPizzas = new List<RatingPizza>
				{
					new RatingPizza
					{
						Pizza = _context.Pizzas.FirstOrDefault(p => p.PizzaID == pizzaId)
					}
				},
				User = _context.Accounts.FirstOrDefault(p => p.AccountID == loggedUser)
			};
			_context.Add(newRating);
			return Page();
		}

		public IActionResult OnPost(string commentText, int id, int rating)
        {
            var accessControl = new AccessControl(_context, _contextAccessor);
            int loggedUser = accessControl.LoggedInAccountID;

            if (string.IsNullOrEmpty(commentText))
            {
                ModelState.AddModelError("Text", "This field can not be empty");
            }

            if (!ModelState.IsValid)
            {
                OnGet(id);
                return Page();
            }

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
            UpdateRatingPizza(id, rating);
            _context.Add(newComment);

            _context.SaveChanges();

            OnGet(id);
            return Page();
        }
        public List<string> GetPhotos()
        {
            string userFolderPath = Path.Combine(
            uploads.FolderPath,
            accessControl.LoggedInAccountID.ToString()
            );

            string[] files = Directory.GetFiles(userFolderPath);

            foreach (string file in files)
            {
                string url = uploads.GetFileURL(file);
                photoUrl.Add(url);
            }
            return photoUrl;
        }
    }
}