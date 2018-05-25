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
		private readonly IdentityDbContext _user = new IdentityDbContext();

		public String GetUsers()
		{
			var t =  _user.Users.
			var s = "";
			foreach(var item in t)
			{
				s += t;
			}
			return s;
			//return _user.GetAll().ToList();
		}
		/*
		public User GetUserById(int id)
		{
			//return _user.FindBy(x => x.UserId == id).Single();
		}

		public string AddUser(User user)
		{
			//return _user.RegisterUser(user);
		}

		public void DeleteUser(User user)
		{
			//_user.Delete(user);
			//_user.Save();
		}*/
	}
}
