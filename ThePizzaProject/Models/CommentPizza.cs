namespace ThePizzaProject.Models
{
    public class CommentPizza
    {
        public int CommentPizzaID { get; set; }
        public Pizza Pizza { get; set; }
        public Comment Comment { get; set; }
    }
}
