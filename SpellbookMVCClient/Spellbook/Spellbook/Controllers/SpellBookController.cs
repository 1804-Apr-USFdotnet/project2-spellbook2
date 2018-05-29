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
    public class SpellbookController : AServiceController
    {
        [HttpPost]
        public ActionResult Add(SpellList newSpellList) {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Edit(SpellList modifiedSpellList) {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> Details(int id) {
            string baseUri = "http://api.cameronwagstaff.net/api/";

            string requestString = baseUri + $"SpellBooks/{id}?populate";

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

            var content = JsonConvert.DeserializeObject<SpellList>(contentString);

            return View(viewName: "SpellbookDetails", model: content);
        }
    }
}