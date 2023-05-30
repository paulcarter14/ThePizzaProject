namespace ThePizzaProject.Models
{
	public class Account
	{
		public int AccountID { get; set; }
		public string OpenIDIssuer { get; set; }
		public string OpenIDSubject { get; set; }
		public string Name { get; set; }
        public List<Pizza> Pizzas { get; set; }

		public List<Comment> Comments { get; set; }
		

		
    }
}
