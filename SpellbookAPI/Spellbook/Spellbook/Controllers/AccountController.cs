using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using Spellbook.Models;
using Spellbook.DataContext;

namespace Spellbook.Controllers
{
	public class AccountController : ApiController
	{

		[HttpPost]
		[AllowAnonymous]
		public IHttpActionResult CreateAccount(User new_user)
		{
			// get db context
			//SpellbookDbContext db = new SpellbookDbContext();
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
				
			return Ok();
		}
	}
}