using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spellbook.Models;
using Spellbook.Repositories;

namespace Spellbook.Services
{
    public class SpellbookService
    {
        private readonly SpellRepository _spells = new SpellRepository();

        public IQueryable<Spell> GetAllSpells()
        {
            return _spells.GetAll();
        }
    }
}
