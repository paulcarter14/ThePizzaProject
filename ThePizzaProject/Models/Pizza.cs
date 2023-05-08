using System.ComponentModel.DataAnnotations;

namespace ThePizzaProject.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }

        //public PizzaIngredient PizzaIngredient { get; set; }

		public List<PizzaIngredient> PizzaIngredients { get; set; }

		public Account User { get; set; }
        public int AccountID { get; set; }

   


    }
}
