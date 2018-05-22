using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Spellbook.Models;
using Spellbook.Services;
using System.Net.Http;


namespace Spellbook.Controllers
{
    public class CharacterController : ApiController
    {
        private readonly SpellbookService _characters = new SpellbookService();

        public IHttpActionResult Get(int id)
        {
            var req = Request.GetQueryNameValuePairs();
            if (req.Count() != 0)
                return BadRequest("Invalid Parameters");
            return Ok(_characters.GetCharacterBy(id));
        }


        public void Post( [FromBody] Character c)
        {
            _characters.AddCharacter(c); // method in order to update info
        }
    }
}