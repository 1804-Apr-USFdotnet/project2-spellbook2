using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Spellbook.Models;
using Spellbook.Services;
using System.Net.Http;

namespace Spellbook.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
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

		public void Put([FromBody] CharacterDTO c)
		{
			_characters.EditCharacter(c);
		}
		public void Post( [FromBody] CharacterDTO c)
		{
			_characters.AddCharacter(c); 
		}

		public void Delete(int id)
		{
			_characters.DeleteCharacter(id);
		}
	}
}