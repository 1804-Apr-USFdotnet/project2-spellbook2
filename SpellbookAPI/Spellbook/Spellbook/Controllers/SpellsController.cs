using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Spellbook.Models;
using Spellbook.Services;

namespace Spellbook.Controllers
{
    public class SpellsController : ApiController {
        private readonly ISpellbookService _service;

        public SpellsController(ISpellbookService service) {
            _service = service;
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            return Ok(_service.GetSpellBy(id));
        }

        [AllowAnonymous]
        public IHttpActionResult Get([FromUri] SpellQuery query)
        {
            try
            {
                query.isNull();
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
