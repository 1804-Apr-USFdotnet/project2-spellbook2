using System.Web.Http;

namespace Spellbook
{
	public static class WebApiConfig
	{
		public static string AuthenticationType = "AuthCookie";
		public static string CookieName = "UserCookie";

		public static void Register(HttpConfiguration config)
		{
			// Web Api config and services
			config.EnableCors();

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new
				{
					id = RouteParameter.Optional
				}
			);
		}
	}
}
