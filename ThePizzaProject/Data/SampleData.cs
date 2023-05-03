using ThePizzaProject.Models;

namespace ThePizzaProject.Data
{
	public class SampleData
	{
		public static void Create(ThePizzaProjectContext database)
		{
			// If there are no fake accounts, add some.
			string fakeIssuer = "https://example.com";
			if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
			{
				database.Accounts.Add(new Account
				{
					OpenIDIssuer = fakeIssuer,
					OpenIDSubject = "1111111111",
					Name = "Brad"
				});
				database.Accounts.Add(new Account
				{
					OpenIDIssuer = fakeIssuer,
					OpenIDSubject = "2222222222",
					Name = "Angelina"
				});
				database.Accounts.Add(new Account
				{
					OpenIDIssuer = fakeIssuer,
					OpenIDSubject = "3333333333",
					Name = "Will"
				});
			}

            if (database.Ingredients.Count() == 0)
			{
				database.Ingredients.Add(new Ingredient
				{
					IngredientName = "Sourdough",
					Amount= 100
				});
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Gluten-free",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Wheat",
                    Amount = 100
                }); database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Broccoli",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Mozzarella",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Cheddar",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Mozzarella",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Brie",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Gorgonzola cheese",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Feta cheese",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Chicken",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Meatballs",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Shrimp",
                    Amount = 100
                }); database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Gorgonzola cheese",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Ham",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Prosciutto",
                    Amount = 100
                });

                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Sausage",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Bacon",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Black Olives",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Green peppers",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Pineapple",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Jalapeños",
                    Amount = 100
                });
            
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Tomatoes",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Anchovies",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Spinach",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Garlic",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Pepperoni",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Mushrooms",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Onions",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Sun-dried tomatoes",
                    Amount = 100
                });
               
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Ricotta cheese",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Basil",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Pesto",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Red peppers",
                    Amount = 100
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Chicken nuggets",
                    Amount = 100
                });
        
            }

                database.SaveChanges();
		}
	}
}
