using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.RegularExpressions;
using SpellbookAPI.DataContext;
using SpellbookAPI.Models;
using SpellbookAPI.Services;

using System.Diagnostics;

namespace Spellbook.Controllers
{
    public class ValuesController : ApiController
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

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
