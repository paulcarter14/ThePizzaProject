using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ThePizzaProject.Models;

namespace ThePizzaProject.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}
	}
}
