using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Spellbook.DataContext;
using Spellbook.Models;
using Spellbook.Services;

namespace Spellbook.Controllers
{
    public class SpellBooksController : ApiController {
        private readonly ISpellbookService _service;

        public SpellBooksController(ISpellbookService service) {
            _service = service;
        }

        public IHttpActionResult Get(int id) {
            return Ok(_service.GetSpellListBy(id));
        }

        public void Put([FromBody] SpellListDTO spellList) {
            _service.EditSpellList(spellList);
        }

        public void Post([FromBody] SpellListDTO spellList) {
            _service.AddSpellList(spellList);
        }

        public void Delete(int id) {
            _service.DeleteSpellList(id);
        }
    }
}
