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
    public class CharacterController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        // GET: Character
        public ActionResult Index()
        {
            return View();
        }



        public async Task<ActionResult> Details(int id) {
            string baseUri = "http://api.cameronwagstaff.net/api/";

            string requestString = baseUri + $"Character/{id}";

            HttpResponseMessage response = await client.GetAsync(requestString);

            if (!response.IsSuccessStatusCode) {
                return View("Error");
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Character>(content);

            return View(viewName: "CharacterDetails", model: result);
        }
    }
}