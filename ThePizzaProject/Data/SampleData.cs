
using ThePizzaProject.Models;

namespace ThePizzaProject.Data
{
	public class SampleData
	{
		public static void Create(ThePizzaProjectContext database)
		{
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
                    Calories = 500
                }); ;
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Gluten-free",
                    Category = "Dough",
                    Calories = 460
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Wheat",
                    Category = "Dough",
                    Calories = 498
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Corndough",
                    Category = "Dough",
                    Calories = 508
                });
                database.Ingredients.Add(new Ingredient
				{
					IngredientName = "Tomato Sauce",
					Category = "Bottom-sauce",
                    Calories = 30
                });
				database.Ingredients.Add(new Ingredient
				{
					IngredientName = "Crème fraiche",
					Category = "Bottom-sauce",
                    Calories = 159
                });
				database.Ingredients.Add(new Ingredient
				{
					IngredientName = "Hot Tomato Sauce",
					Category = "Bottom-sauce",
                    Calories = 50
                });
				database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Mozzarella",
                    Category = "Cheese",
                    Calories = 243
                }) ; 
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Cheddar",
                    Category = "Cheese",
                    Calories = 254
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Brie",
                    Category = "Cheese",
                    Calories = 167
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Gorgonzola cheese",
                    Category = "Cheese",
                    Calories = 231
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Feta cheese",
                    Category = "Cheese",
                    Calories = 210
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Chévre",
                    Category = "Cheese",
                    Calories = 216
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Ricotta cheese",
                    Category = "Cheese",
                    Calories = 198
                });
				database.Ingredients.Add(new Ingredient
				{
					IngredientName = "Parmesan",
					Category = "Cheese",
                    Calories = 125
                });
				database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Chicken",
                    Category = "Chicken",
                    Calories = 178
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Meatballs",
                    Category = "Meat",
                    Calories = 139
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Shrimp",
                    Category = "Fish",
                    Calories = 121
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Ham",
                    Category = "Meat",
                    Calories = 157
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Chicken nuggets",
                    Category = "Chicken",
                    Calories = 203
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Prosciutto",
                    Category = "Meat",
                    Calories = 143
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Anchovies",
                    Category = "Fish",
                    Calories = 56
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Sausage",
                    Category = "Meat",
                    Calories = 231
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Bacon",
                    Category = "Meat",
                    Calories = 245
                });
				database.Ingredients.Add(new Ingredient
				{
					IngredientName = "Salami",
					Category = "Meat",
                    Calories = 98
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Beef",
                    Category = "Meat",
                    Calories = 198
                });
				database.Ingredients.Add(new Ingredient
				{
					IngredientName = "Kebab",
					Category = "Meat",
                    Calories = 258
                });
				database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Black Olives",
                    Category = "Vegetables",
                    Calories = 32
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Green peppers",
                    Category = "Vegetables",
                    Calories = 43
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Pineapple",
                    Category = "Vegetables",
                    Calories = 19
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Jalapeños",
                    Category = "Vegetables",
                    Calories = 20
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Tomatoes",
                    Category = "Vegetables",
                    Calories = 21
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Spinach",
                    Category = "Vegetables",
                    Calories = 32
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Garlic",
                    Category = "Vegetables",
                    Calories = 12
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Pepperoni",
                    Category = "Vegetables",
                    Calories = 32
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Mushrooms",
                    Category = "Vegetables",
                    Calories = 36
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Onions",
                    Category = "Vegetables",
                    Calories = 37
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Sun-dried tomatoes",
                    Category = "Vegetables",
                    Calories = 37
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Basil",
                    Category = "Vegetables",
                    Calories = 12
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Red peppers",
                    Category = "Vegetables",
                    Calories = 5
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Broccoli",
                    Category = "Vegetables",
                    Calories = 21
                });
				database.Ingredients.Add(new Ingredient
				{
					IngredientName = "Paprika",
					Category = "Vegetables",
                    Calories = 34
                });
				database.Ingredients.Add(new Ingredient
				{
					IngredientName = "Artichoke",
					Category = "Vegetables",
                    Calories = 12
                });
				database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Kebab sauce",
                    Category = "Sauces",
                    Calories = 50
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Garlic sauce",
                    Category = "Sauces",
                    Calories = 98
                });
                database.Ingredients.Add(new Ingredient
                {
                    IngredientName = "Pesto",
                    Category = "Sauces",
                    Calories = 87
                });
            }
                database.SaveChanges();
		}
	}
}