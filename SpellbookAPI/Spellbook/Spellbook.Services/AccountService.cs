using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Spellbook.Models;

namespace Spellbook.Services
{
	public class AccountService
	{
		public string CreateAccount(User user)
		{
			var store = new UserStore<IdentityUser>(new IdentityDbContext<IdentityUser>("UserContext"));
			var manager = new UserManager<IdentityUser>(store);
			var u = new IdentityUser(user.Name);

			//check if username is taken
			if (manager.Users.Any(x => x.UserName == user.Name))
				return "Username Taken";

			if (manager.Create(u, user.Password).Succeeded)
				return "Account Created";

			return "Something went wrong";
		}
	}
}
