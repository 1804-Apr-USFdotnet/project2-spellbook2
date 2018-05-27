using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;

using Spellbook.Controllers;

[assembly: OwinStartup(typeof(Spellbook.Startup))]

namespace Spellbook
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{

			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
			//app.CreatePerOwinContext();
			app.UseCookieAuthentication(new CookieAuthenticationOptions()
			{
				AuthenticationType = WebApiConfig.AuthenticationType,
				CookieName = WebApiConfig.CookieName
			});

			//app.CreatePerOwinContext<AccountController>(AccountController);
		}
	}
}