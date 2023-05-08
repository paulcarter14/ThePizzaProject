using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThePizzaProject.Data;

namespace ThePizzaProject.Pages.Shared.Components.LoginMenu
{
	public class FakeLoginMenu : ViewComponent
	{
		private readonly ThePizzaProjectContext database;
		private readonly AccessControl accessControl;

		public FakeLoginMenu(ThePizzaProjectContext database, AccessControl accessControl)
		{
			this.database = database;
			this.accessControl = accessControl;
		}

		public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
		{
			var accounts = database.Accounts.OrderBy(a => a.Name);
			var selectList = accounts.Select(p => new SelectListItem
			{
				Value = p.AccountID.ToString(),
				Text = p.Name,
				Selected = p.AccountID == accessControl.LoggedInAccountID
			});
			return View(selectList);
		}
	}
}
