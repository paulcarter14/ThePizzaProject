using System.ComponentModel.DataAnnotations;

namespace ThePizzaProject.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }
        public List<CommentPizza> CommentPizza { get; set; }
		public List<PizzaIngredient> PizzaIngredients { get; set; }
        public List<RatingPizza> RatingPizzas { get; set; }
		public Account User { get; set; }
        public int AccountID { get; set; } 
    }
}