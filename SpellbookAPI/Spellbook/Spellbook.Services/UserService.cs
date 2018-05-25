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

		public async Task<string> GetUsersAsync(int id)
		{
			var x = await _user.GetUserByIdAsync(id);
			return x;
		}
		/*
		public User GetUserById(int id)
		{
			//return _user.FindBy(x => x.UserId == id).Single();
		}*/

		public string AddUser(User user)
		{
			return _user.RegisterUser(user);
		}

		public string LogIn(User user)
		{
			return _user.UserLogIn(user);
		}

		/*
		public void DeleteUser(User user)
		{
			//_user.Delete(user);
			//_user.Save();
		}*/
	}
}
