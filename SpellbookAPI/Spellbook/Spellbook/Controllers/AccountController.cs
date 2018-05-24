using System;
using System.Web.ApplicationServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;


using Spellbook.Models;
using Spellbook.DataContext;

namespace Spellbook.Controllers
{
	public class AccountController : ApiController
	{
		// create user db context here
		UserDbContext _user = new UserDbContext();


		[HttpGet]
		[Route("~/api/Account/Get")]
		[AllowAnonymous]
		public IHttpActionResult Get()
		{
			string t = "";
			foreach (var item in _user.Users.ToList())
			{
				t += item.Name;
			}
			return Ok(t);
		}

		[HttpPost]
		[Route("~/api/Account/Create")]
		[AllowAnonymous]
		public IHttpActionResult Create(User user)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			if (_user.Users.ToList().Contains(user))
			{
				return BadRequest("User already exist");
			}

			_user.Users.Add(user);
			_user.SaveChanges();

			// check if email already exist 
			/*if (_user.GetAll().Any(x => x.Email == user.Email))
			{
				return BadRequest("Email already exist");
			}*/

			// no user found, create a new one
			//_user.Add(user);

			return Ok(user.Name + user.Password);
		}

		[HttpDelete]
		public IHttpActionResult DeleteAccount(User user)
		{
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		public IHttpActionResult LogIn(User user)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			return Ok();
		}

		[HttpGet]
		public IHttpActionResult LogOut()
		{
			Request.GetOwinContext().Authentication.SignOut(WebApiConfig.AuthenticationType);
			return Ok();
		}
	}
}