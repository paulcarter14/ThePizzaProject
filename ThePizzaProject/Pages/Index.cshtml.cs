﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;
using ThePizzaProject.Data;
using ThePizzaProject.Models;

namespace ThePizzaProject.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ThePizzaProjectContext _context;

		public IndexModel(ThePizzaProjectContext context)
		{
			_context = context;
			Ingredients = new List<Ingredient>(); // Initialize the Ingredients property
		}

		public List<Ingredient> Ingredients { get; set; }
		public List<Pizza> Pizzas { get; set; }
		public List<Pizza> MyPizzas { get; set; }

		public void OnGet()
		{
			Pizzas = _context.Pizzas.Include(p => p.PizzaIngredients).ToList();

			MyPizzas = GetMyPizzas(); // Get only your pizzas
			Ingredients = _context.Ingredients.ToList(); // Populate the Ingredients property
		}

		private List<Pizza> GetMyPizzas()
		{
			List<Pizza> myPizzas =
				(
					from p in _context.Pizzas
					where p.AccountID == p.AccountID// Filter by the current user's account ID
					select new Pizza
					{
						PizzaID = p.PizzaID,
						PizzaName = p.PizzaName,
						PizzaIngredients = (
							from pi in p.PizzaIngredients
							select new PizzaIngredient
							{
								PizzaIngredientID = pi.PizzaIngredientID,
								Pizza = null,
								Ingredient = new Ingredient
								{
									IngredientID = pi.Ingredient.IngredientID,
									IngredientName = pi.Ingredient.IngredientName,
									Category = pi.Ingredient.Category,
									PizzaIngredients = null
								}
							}).ToList(),
						User = p.User,
						AccountID = p.AccountID
					}).ToList();

			return myPizzas;
		}
	}
}