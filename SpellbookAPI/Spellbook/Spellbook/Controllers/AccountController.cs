using System;
using System.Web.ApplicationServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;


using Spellbook.Models;
using Spellbook.Services;
using Spellbook.DataContext;

namespace Spellbook.Controllers
{
	public class AccountController : ApiController
	{
		private readonly UserService _userService = new UserService();

		[HttpGet]
		[Route("~/api/Account/Get")]
		[AllowAnonymous]
		public IHttpActionResult Get()
		{
			return Ok(_userService.GetUsersAsync(1));
			//return Ok(String.Join(", ", _userService.GetUsers().Select(x => x.Name)));
		}
		/*
		[HttpGet]
		[Route("~/api/Account/Get")]
		[AllowAnonymous]
		public IHttpActionResult Get(int id)
		{
			return Ok(_userService.GetUserById(id).Name);
		}*/

		[HttpPost]
		[Route("~/api/Account/Create")]
		[AllowAnonymous]
		public IHttpActionResult Create(User user)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			return Ok(_userService.AddUser(user));
		}

		/*
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
		}*/
	}
}