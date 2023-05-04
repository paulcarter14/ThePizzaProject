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
		public DbSet<PizzaIngredient> Toppings { get; set; }

		public ThePizzaProjectContext(DbContextOptions<ThePizzaProjectContext> options)
			: base(options)
		{
		}

	}
}
