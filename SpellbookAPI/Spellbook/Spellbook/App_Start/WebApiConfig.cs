using System.Web.Http;
using System.Web.Http.Cors;

namespace Spellbook
{
	public static class WebApiConfig
	{
		public static string AuthenticationType = "AuthCookie";
		public static string CookieName = "ApocalypseCookie";

		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
		    var corsPolicy = new EnableCorsAttribute("http://oldspellbook.cameronwagstaff.net,http://spellbook.cameronwagstaff.net,http://localhost:8080,http://localhost:4200", "*", "*");
		    corsPolicy.SupportsCredentials = true;
			config.EnableCors(corsPolicy);

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Filters.Add(new AuthorizeAttribute());

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
