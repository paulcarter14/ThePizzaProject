﻿using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ThePizzaProject.Data;
using ThePizzaProject.Models;

namespace ThePizzaProject.Data
{
	public class AccessControl
	{
		public int LoggedInAccountID { get; set; }
		public string LoggedInAccountName { get; set; }

		public AccessControl(ThePizzaProjectContext db, IHttpContextAccessor httpContextAccessor)
		{
			var user = httpContextAccessor.HttpContext.User;
			string subject = user.FindFirst(ClaimTypes.NameIdentifier).Value;
			string issuer = user.FindFirst(ClaimTypes.NameIdentifier).Issuer;

			LoggedInAccountID = db.Accounts.Single(p => p.OpenIDIssuer == issuer && p.OpenIDSubject == subject).AccountID;
			LoggedInAccountName = user.FindFirst(ClaimTypes.Name).Value;
		}
	}
}
