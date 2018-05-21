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

        public async Task<ActionResult> QuickSearch(string query, string filter)
        {
            // todo HARD CODE BIG NONO STOP NOW
            HttpResponseMessage response = await client.GetAsync($"http://localhost:58987/api/Spells?q={query}&filter={filter}");

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