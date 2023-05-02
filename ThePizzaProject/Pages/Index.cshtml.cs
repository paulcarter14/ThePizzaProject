using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThePizzaProject.Data;

namespace ThePizzaProject.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ThePizzaProjectContext database;

		public IndexModel(ThePizzaProjectContext database)
		{
			this.database = database;
		}

		public void OnGet()
		{

		}
	}
}