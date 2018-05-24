using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Spellbook.Models;
using Spellbook.Repositories;

namespace Spellbook.Services
{
	public class UserService
	{
		private readonly UserRepository _user = new UserRepository();

		public IEnumerable<User> GetUsers()
		{
			return _user.GetAll().ToList()
		}

		public User GetUserById(int id)
		{
			return _user.FindBy(x => x.UserId == id).Single();
		}

		public void AddUser(User user)
		{
			var userStore = new UserStore<IdentityUser>();
		}

		public void DeleteUser(User user)
		{
			_user.Delete(user);
			_user.Save();
		}
	}
}
