using ThePizzaProject.Models;

namespace ThePizzaProject.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
    }

    public class CommentViewModel
    {
        public string UserName { get; set; }
        public string Comment { get; set; }

        public DateTime DateTime { get; set; }
    }

    public class IngredientViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Kcal { get; set; }
        public string Category { get; set; }
    }
}
