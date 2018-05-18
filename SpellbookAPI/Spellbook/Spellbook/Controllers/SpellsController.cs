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
        private readonly SpellbookService _Service = new SpellbookService();
        // GET api/values
        public IEnumerable<Spell> Get()
        {
            return _Service.GetAllSpells();
        }

        // GET api/values/5
        public Spell Get(int id)
        {
            //comment
            return _Service.GetSpellBy(id);
        }
    }
}
