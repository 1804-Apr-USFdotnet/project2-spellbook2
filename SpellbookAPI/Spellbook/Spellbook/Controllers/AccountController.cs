using System.Web.Http;

using Spellbook.Models;
using Spellbook.Services;

namespace Spellbook.Controllers
{
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

			return Ok(result);
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