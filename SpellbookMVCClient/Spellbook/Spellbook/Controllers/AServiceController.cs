using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Spellbook.Controllers
{
	public abstract class AServiceController : Controller
	{
		protected static readonly HttpClient HttpClient = new HttpClient(new HttpClientHandler() { UseCookies = false });
		private static readonly Uri serviceUri = new Uri("http://api.cameronwagstaff.net/api/");
		private static readonly string cookieName = "ApocalypseCookie";

		protected HttpRequestMessage CreateRequestToService(HttpMethod method, string uri)
		{
			var apiRequest = new HttpRequestMessage(method, new Uri(serviceUri, uri));

			string cookieValue = Request.Cookies[cookieName]?.Value ?? ""; // ?. operator new in C# 7

			apiRequest.Headers.Add("Cookie", new CookieHeaderValue(cookieName, cookieValue).ToString());

			return apiRequest;
		}
	}
}