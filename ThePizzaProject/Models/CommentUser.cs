namespace ThePizzaProject.Models
{
	public class CommentUser
	{
		public int CommentUserID { get; set; }

		public Account user { get; set; }

		public Comment Comment { get; set; }
	}
}
