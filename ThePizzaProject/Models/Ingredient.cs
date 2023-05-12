using System.ComponentModel.DataAnnotations;

namespace ThePizzaProject.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }
        
        public string IngredientName { get; set; }
        public string Category { get; set; }

       public int Calories { get; set; }

		public List<PizzaIngredient> PizzaIngredients { get; set; }


	}
}
