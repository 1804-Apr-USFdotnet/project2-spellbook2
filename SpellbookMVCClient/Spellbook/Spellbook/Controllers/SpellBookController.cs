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
    public class SpellbookController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        
        public async Task<ActionResult> SpellbookDetails(int id) {
            string baseUri = "http://api.cameronwagstaff.net/api/";

            string requestString = baseUri + $"SpellBooks/{id}?populate";

            HttpResponseMessage response = await client.GetAsync(requestString);

            if (!response.IsSuccessStatusCode) {
                return View("Error");
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SpellList>(content);
            
            // not necessary with the populate option for spellbook lookup
            /*
            result.Spells = new List<Spell>();
            foreach (int spellId in result.SpellIds) {
                response = await client.GetAsync(baseUri + $"Spells/{spellId}");

                if (!response.IsSuccessStatusCode) {
                    return View("Error");
                }

                content = await response.Content.ReadAsStringAsync();

                result.Spells.Add(JsonConvert.DeserializeObject<Spell>(content));
            }*/
            
            return View(viewName: "SpellBookDetails", model: result);
        }
    }
}