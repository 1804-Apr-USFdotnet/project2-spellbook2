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

		public ActionResult Login()
		{
			return View(viewName: "LogIn");
		}

		public ActionResult Create()
		{
			return View(viewName: "CreateView");
		}

		[HttpPost]
		public async Task<ActionResult> Create(User user)
		{
			// redirect to home after logging in
			HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "Account/Create");
			apiRequest.Content = new ObjectContent<User>(user, new JsonMediaTypeFormatter());

			HttpResponseMessage apiResponse;
			try
			{
				apiResponse = await HttpClient.SendAsync(apiRequest);
				var x = await apiResponse.Content.ReadAsAsync<Message>();
				if (x.message == "Username Taken" || x.message == "Something went wrong")
				{
					// do something here
					return View(viewName: "CreateView");
				}
			}
			catch
			{
				return View(viewName: "CreateView");
			}

			if (!apiResponse.IsSuccessStatusCode)
			{
				return View(viewName: "CreateView");
			}

			PassCookiesToClient(apiResponse);
			return View("Index", "Home");
		}

		[HttpPost]
		public async Task<ActionResult> Login(User user)
		{
			user.Phone = 123456;
			user.Email = "test@gmail.com";

			HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "Account/LogIn");
			apiRequest.Content = new ObjectContent<User>(user, new JsonMediaTypeFormatter());

			HttpResponseMessage apiResponse;
			try
			{
				apiResponse = await HttpClient.SendAsync(apiRequest);
				var x = await apiResponse.Content.ReadAsAsync<Message>();
				ViewBag.Message = x.message;
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

		public async Task<ActionResult> LogOut()
		{
			if (!ModelState.IsValid)
				return View("Error");

			HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "Account/LogOut");

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

	public class Message
	{
		public string name { get; set; }
		public string message { get; set; }
	}
}
