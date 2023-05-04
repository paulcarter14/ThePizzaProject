using System.ComponentModel.DataAnnotations;

namespace ThePizzaProject.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }

        public Account User { get; set; }
        public int AcountID { get; set; }
        public ICollection<PizzaIngredient> PizzaIngredients { get; set; }


    }
}
