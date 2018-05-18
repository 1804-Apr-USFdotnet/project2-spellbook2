using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Spellbook.Models;

namespace Spellbook.Controllers
{
	public class AccountController : ApiController
	{
		[HttpPost]
		public IHttpActionResult CreateAccount(User new_user)
		{
			// placeholder
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
			return Ok();
		}

		[HttpGet]
		public IHttpActionResult LogOut()
		{
			return Ok();
		}
	}
}