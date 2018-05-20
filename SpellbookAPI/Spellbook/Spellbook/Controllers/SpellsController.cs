using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Spellbook.Models;
using Spellbook.Services;

namespace Spellbook.Controllers
{
    public class SpellsController : ApiController
    {
        private readonly SpellbookService _service = new SpellbookService();
        // GET api/values
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAllSpells());
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            //comment
            return Ok(_service.GetSpellBy(id));
        }

        public IHttpActionResult Get(string queryString, string filter)
        {
            string[] availableFilters = { "levels", "classes", "schools" };
            try
            {
                if (!availableFilters.Contains(filter))
                {
                    return BadRequest("Your filter was inccorect! :(");
                }
                else
                {
                    return Ok(_service.GetSpellBy(queryString, filter));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
