using System.ComponentModel.DataAnnotations.Schema;
namespace ThePizzaProject.Models
{
	public class RatingPizza
	{
		public int ratingPizzaId { get; set; }
		public Pizza Pizza { get; set; }
		public Rating Rating { get; set; }
	}
}
