using System.Web.Http;
using Spellbook.Models;

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