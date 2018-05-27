using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Spellbook.Models;

namespace Spellbook.Controllers
{
	public class AccountController : AServiceController
	{
		private static readonly HttpClient client = new HttpClient();

		[HttpPost]
		public async Task<ActionResult> LogIn(User user)
		{
			HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "Account/LogIn");
			apiRequest.Content = new ObjectContent<User>(user, new JsonMediaTypeFormatter());

			HttpResponseMessage apiResponse;
			try
			{
				apiResponse = await HttpClient.SendAsync(apiRequest);
			}
			catch
			{
				return View("Error");
			}

			if (!apiResponse.IsSuccessStatusCode)
			{
				return View("Error");
			}

			PassCookiesToClient(apiResponse);

			return RedirectToAction("Index", "Home");
		}

		private bool PassCookiesToClient(HttpResponseMessage apiResponse)
		{
			if (apiResponse.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values))
			{
				foreach (string value in values)
				{
					Response.Headers.Add("Set-Cookie", value);
				}
				return true;
			}
			return false;
		}

	}
}
