using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThePizzaProject.Data;

namespace ThePizzaProject.Pages
{
	public class IndexModel : PageModel
	{
		private readonly AppDbContext database;

		public IndexModel(AppDbContext database)
		{
			this.database = database;
		}

		public void OnGet()
		{

		}
	}
}