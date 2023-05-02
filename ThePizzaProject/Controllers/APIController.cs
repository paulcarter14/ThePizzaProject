using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePizzaProject.Data;

namespace ThePizzaProject.Controllers
{
	[Route("/api")]
	[ApiController]
	public class APIController : ControllerBase
	{
		private readonly ThePizzaProjectContext database;

		public APIController(ThePizzaProjectContext database)
		{
			this.database = database;
		}
	}
}
