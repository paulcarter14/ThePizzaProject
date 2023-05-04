
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
                    Category = "Dough",
                }); ;
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Gluten-free",
                    Category = "Dough",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Wheat",
                    Category = "Dough",
                });




                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Mozzarella",
                    Category = "Cheese",
                }) ; 
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Cheddar",
                    Category = "Cheese",
                });
               
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Brie",
                    Category = "Cheese",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Gorgonzola cheese",
                    Category = "Cheese",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Feta cheese",
                    Category = "Cheese",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Gorgonzola cheese",
                    Category = "Cheese",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Ricotta cheese",
                    Category = "Cheese",
                });




                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Chicken",
                    Category = "Protein",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Meatballs",
                    Category = "Protein",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Shrimp",
                    Category = "Protein",
                });

                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Ham",
                    Category = "Protein",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Chicken nuggets",
                    Category = "Protein",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Prosciutto",
                    Category = "Protein",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Anchovies",
                    Category = "Protein",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Sausage",
                    Category = "Protein",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Bacon",
                    Category = "Protein",
                });




                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Black Olives",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Green peppers",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Pineapple",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Jalapeños",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Tomatoes",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Spinach",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Garlic",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Pepperoni",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Mushrooms",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Onions",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Sun-dried tomatoes",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Basil",
                    Category = "Vegetables",
                });
                
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Red peppers",
                    Category = "Vegetables",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Broccoli",
                    Category = "Vegetables",
                });



                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Kebab sauce",
                    Category = "Sauces",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Garlic sauce",
                    Category = "Sauces",
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Pesto",
                    Category = "Sauces",
                });
            }

                database.SaveChanges();
		}
	}
}
