using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spellbook.Models;
using Spellbook.Services;

namespace Spellbook.Controllers
{
    public class CharacterController : Controller
    {
        private readonly SpellbookService service = new SpellbookService();
        // GET: Character
        public ActionResult Index()
        {
            return View();
        }

     public Character Get(int id)
        {
            return service.GetCharacterBy(id);
        }
    }
}