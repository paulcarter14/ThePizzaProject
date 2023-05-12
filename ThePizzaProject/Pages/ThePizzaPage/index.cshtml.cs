using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThePizzaProject.Data;
using ThePizzaProject.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

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

		public Pizza Pizzas { get; set; }
		public CommentPizza commentPizza { get; set; }
		public List<Ingredient> Ingredients { get; set; }

		public List<Comment> Comments { get; set; }


		public void OnGet(int id)
		{
			var myPizza = _context.Pizzas
				.Where(p => p.PizzaID == id)
				 .Include(p => p.CommentPizza.Where(cp => cp.Pizza.PizzaID == id))
					
				 .Include(p => p.CommentPizza)
				
				.ThenInclude(cp => cp.Comment)
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
			else
			{
				Pizzas = myPizza;
				if (myPizza.CommentPizza != null)
				{
					var comments = myPizza?.CommentPizza
						.Select(cp => cp.Comment)
						.ToList();
					
					


					Comments = comments;
				}
				else
				{
					Comments = new List<Comment>();
				}

			}
		}

		public void OnPost(string commentText, int id)
		{
			var pizza = _context.Pizzas.FirstOrDefault(p => p.PizzaID == id);

			var accessControl = new AccessControl(_context, _contextAccessor);
			int loggedUser = accessControl.LoggedInAccountID;

			Account user = (Account)_context.Accounts.FirstOrDefault(a => a.AccountID == loggedUser);



			Comment newComment = new Comment
			{

				CommentText = commentText,

			};

			CommentPizza newCommentPizza = new CommentPizza
			{
				Pizza = pizza,
				Comment = newComment

			};

			CommentUser commentUser = new CommentUser
			{
				Comment = newComment,
				user = user
			};



			//newCommentPizza.Comment.CommentUser = 

			// add the comment pizza to the comment's list of comment pizzas
			newComment.CommentPizzas = new List<CommentPizza> {

				newCommentPizza

			};

			_context.Add(newComment);
			_context.Add(newCommentPizza);
			_context.Add(commentUser);
			_context.SaveChanges();

			OnGet(id);

		}
	}
}