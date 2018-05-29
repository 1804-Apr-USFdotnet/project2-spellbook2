using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Spellbook.Models;
using Newtonsoft.Json;

namespace Spellbook.Controllers
{
    public class HomeController : AServiceController
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> QuickSearch(string school, string classes, string levels) {
            string baseUri = "http://api.cameronwagstaff.net/api/Spells?";

            string requestString = baseUri + $"school={school}&classes={classes}&levels={levels}";

            HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, requestString);

            HttpResponseMessage response;
            try {
                response = await HttpClient.SendAsync(request);
            }
            catch {
                return View("Error");
            }

            if (!response.IsSuccessStatusCode) {
                return View("Error");
            }

            var contentString = await response.Content.ReadAsStringAsync();

            var content = JsonConvert.DeserializeObject<IEnumerable<Spell>>(contentString);

            return View(viewName: "Search", model: content);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}