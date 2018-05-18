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
        public IEnumerable<Spell> Get()
        {
            return _service.GetAllSpells();
        }

        // GET api/values/5
        public Spell Get(int id)
        {
            return _service.GetSpellBy(id);
        }
    }
}
