using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Spellbook.Models;

namespace Spellbook.Controllers
{
    public class SpellController : Controller {
        private static readonly HttpClient client = new HttpClient();

        // GET: Spell
        public async Task<ActionResult> SpellDetails(int id) {
            string baseUri = "http://api.cameronwagstaff.net/api/";

            string requestString = baseUri + $"Spells/{id}";

            HttpResponseMessage response = await client.GetAsync(requestString);

            if (!response.IsSuccessStatusCode) {
                return View("Error");
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Spell>(content);
            
            return View(viewName: "SpellDetails", model: result);
        }
    }
}