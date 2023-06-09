﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Security.Principal;
using ThePizzaProject.Data;
using ThePizzaProject.Models;

namespace ThePizzaProject.Pages
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
			Ingredients = new List<Ingredient>();
			this._contextAccessor = httpContextAccessor;
			this.accessControl = accessControl;
			this.uploads = uploads;
		}

		public List<Ingredient> Ingredients { get; set; }
		public List<Pizza> Pizzas { get; set; }
		public List<Pizza> MyPizzas { get; set; }
		public List<string> photoUrl = new List<string>();

		public void OnGet()
		{
			Pizzas = _context.Pizzas.Include(p => p.PizzaIngredients).ToList();
			MyPizzas = GetMyPizzas();
			Ingredients = _context.Ingredients.ToList();
            GetPhotos();
        }

		private List<Pizza> GetMyPizzas()
		{
			var accessControl = new AccessControl(_context, _contextAccessor);
			int loggedUser = accessControl.LoggedInAccountID;
			List<Pizza> myPizzas =
				(
					from p in _context.Pizzas
					where p.AccountID == loggedUser
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

			 GetPizzaPhoto();

            return myPizzas ;
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

        public List<string> GetPizzaPhoto()
		{
			string userFolderPath = Path.Combine(
			uploads.FolderPath,
			accessControl.LoggedInAccountID.ToString()
			);
			if (Directory.Exists(userFolderPath))
			{
                string[] files = Directory.GetFiles(userFolderPath);

                foreach (string file in files)
                {
                    string url = uploads.GetFileURL(file);
                    photoUrl.Add(url);
                }
            }
			else
			{
                Directory.CreateDirectory(userFolderPath);
            }
            return photoUrl;
		}
	}
}