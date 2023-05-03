using System.ComponentModel.DataAnnotations;

namespace ThePizzaProject.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }
        public int Amount { get; set; }
        public string IngredientName { get; set; }
        public string Category { get; set; }





        //public string bottom { get; set; }
        //public bool cheese { get; set; }
        //public bool ham { get; set; }
        //public bool peperoni { get; set; }
        //public bool kebab { get; set; }
        //public bool banana { get; set; }
        //public bool tomatosause { get; set; }
        //public bool tomato { get; set; }
        //public bool olivs { get; set; }
        //public bool chicken { get; set; }
        //public bool brie { get; set; }
    }
}
