using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories
{
	public class UserRepository : ARepository<UserDbContext, User>
	{
		public string RegisterUser(User user)
		{
			var userStore = new UserStore<IdentityUser>(new IdentityDbContext<IdentityUser>("UserContext"));
			var userManager = new UserManager<IdentityUser>(userStore);
			var u = new IdentityUser(user.Name);

			var result = userManager.Create(u, user.Password);
			if (result.Succeeded)
			{
				return "succeeded";
			}
			else
			{
				return "failed";
			}
		}
	}
}
