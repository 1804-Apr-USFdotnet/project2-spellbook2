using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Spellbook.Models;
using Spellbook.Services;

namespace Spellbook.Controllers
{
    public class SpellsController : ApiController
    {
        private readonly SpellbookService _service = new SpellbookService();
 
        public IHttpActionResult Get()
        {
            var req = Request.GetQueryNameValuePairs();
            if(req.Count() != 0)
                return BadRequest("Invalid Parameters! :(");
            return Ok(_service.GetAllSpells());
        }

        public IHttpActionResult Get(int id)
        {
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

                return Ok(_service.GetSpellBy(queryString, filter));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IHttpActionResult Get([FromUri] SpellQuery query)
        {
            try
            {
                if (!query.isValid())
                    return BadRequest("Query is not valid. :(");
                return Ok(_service.GetSpellBy(query));
            }
            catch (Exception EX_NAME)
            {
                Console.WriteLine(EX_NAME);
                throw;
            }
        }
    }
}
