namespace ThePizzaProject.Models
{
	public class Rating
	{
		public int ratingId { get; set; }
		public int ratingValue { get; set; }
		public List<RatingPizza> RatingPizzas { get; set; }
		public Account User { get; set; }
	}
}
