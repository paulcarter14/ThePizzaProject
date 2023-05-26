using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ThePizzaProject.Models;

namespace ThePizzaProject.Data
{
	public class ThePizzaProjectContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Ingredient> Ingredients { get; set;}
		public DbSet<Pizza> Pizzas { get; set; }

		

		public DbSet<CommentPizza> CommentPizza { get; set; }

		public DbSet<PizzaIngredient> PizzaIngredient { get; set; }

		public DbSet<Comment> Comments { get; set; }
		//public DbSet<PizzaIngredient> PizzaIngredients { get; set; }

		public DbSet<Rating> Rating { get; set; }
		public DbSet<RatingPizza> RatingPizza { get; set; }

		public ThePizzaProjectContext(DbContextOptions<ThePizzaProjectContext> options)
			: base(options)
		{
		}

	}
}
