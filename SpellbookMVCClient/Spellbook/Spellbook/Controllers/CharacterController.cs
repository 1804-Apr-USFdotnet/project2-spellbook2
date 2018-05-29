using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Spellbook.Models;

namespace Spellbook.Controllers
{
    public class CharacterController : AServiceController
    {
        // GET: Character
        public async Task<ActionResult> Index() {
            string baseUri = "http://api.cameronwagstaff.net/api/";

            string requestString = baseUri + "Character";

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

            var content = JsonConvert.DeserializeObject<IEnumerable<Character>>(contentString);

            return View(viewName: "ListCharacters", model: content);
        }

        public ActionResult Create() {
            return View(viewName: "CreateCharacter", model: new Character(){Spellbook = new SpellList(){SpellListId = 1}});
        }

        [HttpPost]
        public async Task<ActionResult> Create(Character character) {
            string baseUri = "http://api.cameronwagstaff.net/api/";

            string requestString = baseUri + "Character";

            HttpRequestMessage request = CreateRequestToService(HttpMethod.Post, requestString);
            request.Content = new ObjectContent<Character>(character, new JsonMediaTypeFormatter());

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

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id) {
            string baseUri = "http://api.cameronwagstaff.net/api/";

            string requestString = baseUri + $"Character/{id}";
            
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

            var content = JsonConvert.DeserializeObject<Character>(contentString);

            return View(viewName: "CharacterDetails", model: content);
        }
    }
}