using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Spellbook.Services;

namespace Spellbook.Controllers
{
    public class SpellBooksController : ApiController
    {
        private readonly SpellbookService _service = new SpellbookService();

        public IHttpActionResult Get(int id) {
            return Ok(_service.GetSpellListBy(id));
        }
    }
}
