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
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> QuickSearch(string school, string classes, string levels) {
            string baseUri = "http://api.cameronwagstaff.net/api/Spells?";

            string requestString = baseUri + $"school={school}&classes={classes}&levels={levels}";

            // todo HARD CODE BIG NONO STOP NOW
            HttpResponseMessage response = await client.GetAsync(requestString);

            if (!response.IsSuccessStatusCode) {
                return View("Error");
            }

            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<IEnumerable<Spell>>(content);

            return View(viewName: "Search", model: results);
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