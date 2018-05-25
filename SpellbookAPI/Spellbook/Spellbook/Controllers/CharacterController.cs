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
        private readonly ISpellbookService _characters;

        public CharacterController(ISpellbookService service) {
            _characters = service;
        }

        public IHttpActionResult Get()
        {
            var req = Request.GetQueryNameValuePairs();
            if (req.Count() != 0)
                return BadRequest("Invalid Parameters");
            return Ok(_characters.GetAllCharacters());
        }

        public IHttpActionResult Get(int id)
        {
            var req = Request.GetQueryNameValuePairs();
            if (req.Count() != 0)
                return BadRequest("Invalid Parameters");
            return Ok(_characters.GetCharacterBy(id));
        }

        public void Put([FromBody] Character c)
        {
            _characters.EditCharacter(c);
        }
        public void Post( [FromBody] Character c)
        {
            _characters.AddCharacter(c); 
        }

        public void Delete(Character c)
        {
            _characters.DeleteCharacter(c);
        }
    }
}