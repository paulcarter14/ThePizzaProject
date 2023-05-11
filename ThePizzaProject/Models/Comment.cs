namespace ThePizzaProject.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
    
        public string CommentText { get; set; }

        public List<CommentPizza> CommentPizzas { get; set; }
    }
}
