using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Spellbook.Models;
using Spellbook.Repositories;

namespace Spellbook.Controllers
{
	public class AccountController : ApiController
	{
		private readonly UserRepository _user = new UserRepository();

		[HttpGet]
		public void Get()
		{
			//return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		public IHttpActionResult CreateAccount(User user)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			// check if email already exist 
			if (_user.GetAll().Any(x => x.Email == user.Email))
			{
				return BadRequest("Email already exist");
			}

			// no user found, create a new one
			_user.Add(user);

			return Ok();
		}

		[HttpDelete]
		public IHttpActionResult DeleteAccount(User user)
		{
			return Ok();
		}

		[HttpPost]
		public IHttpActionResult LogIn(User user)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return Ok();
		}

		[HttpGet]
		public IHttpActionResult LogOut()
		{
			Request.GetOwinContext().Authentication.SignOut();
			return Ok();
		}
	}
}