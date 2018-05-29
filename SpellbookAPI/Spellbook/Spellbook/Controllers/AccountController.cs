using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

using Spellbook.Models;
using Spellbook.Services;

namespace Spellbook.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class AccountController : ApiController
	{
		private readonly AccountService _accountService = new AccountService();

		[HttpPost]
		[Route("~/api/Account/Create")]
		[AllowAnonymous]
		public IHttpActionResult CreateAccount(User user)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var result = _accountService.CreateAccount(user);
			if ( result == "Username Taken" || result == "Something went wrong")
				return BadRequest(result);

			return Ok(new Message { message = result});
		}

		[HttpDelete]
		[Route("~/api/Account/Delete")]
		public IHttpActionResult DeleteAccount(User user)
		{
			if(!ModelState.IsValid)
				return BadRequest();

			var store = new UserStore<IdentityUser>(new IdentityDbContext<IdentityUser>("UserContext"));
			var manager = new UserManager<IdentityUser>(store);
			var account = manager.Users.FirstOrDefault(x => x.UserName == user.Name);

			manager.Delete(account);

			return Ok();
		}

		[HttpPost]
		[Route("~/api/Account/LogIn")]
		[AllowAnonymous]
		public IHttpActionResult LogIn(User user)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var store = new UserStore<IdentityUser>(new IdentityDbContext<IdentityUser>("UserContext"));
			var manager = new UserManager<IdentityUser>(store);
			var account = manager.Users.FirstOrDefault(x => x.UserName == user.Name);

			if (account == null || !manager.CheckPassword(account, user.Password))
				return Unauthorized();

			var authManager = Request.GetOwinContext().Authentication;
			var claimsIdentity = manager.CreateIdentity(account, WebApiConfig.AuthenticationType);

			authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claimsIdentity);

			return Ok(new Message { name = user.Name, message = "logged in"});

		}

		[HttpGet]
		[AllowAnonymous]
		[Route("~/api/Account/Logout")]
		public IHttpActionResult LogOut()
		{
			Request.GetOwinContext().Authentication.SignOut(WebApiConfig.AuthenticationType);
			return Ok(new Message { message = "Logged Out" });
		}
	}
}