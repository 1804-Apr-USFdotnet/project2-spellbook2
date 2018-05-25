using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using Microsoft.Owin.Security;
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

		public async Task<string> GetUserByIdAsync(int id)
		{
			var userStore = new UserStore<IdentityUser>(new IdentityDbContext<IdentityUser>("UserContext"));
			var x =  await userStore.FindByIdAsync(id.ToString());

			return x.UserName;
		}

		public object UserLogIn(User user)
		{
			var userStore = new UserStore<IdentityUser>(new IdentityDbContext<IdentityUser>("UserContext"));
			var userManager = new UserManager<IdentityUser>(userStore);

			var login = userManager.Users.FirstOrDefault(x => x.UserName == user.Name);

			if (login == null || !userManager.CheckPassword(login, user.Password))
			{
				return null;
			}

			return userManager;
		}
	}
}
