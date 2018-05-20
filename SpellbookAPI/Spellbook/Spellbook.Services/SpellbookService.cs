using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Spellbook.Models;
using Spellbook.Repositories;

namespace Spellbook.Services
{
    public class SpellbookService
    {
        private readonly SpellRepository _spells = new SpellRepository();
        private readonly SpellListRepository _spellLists = new SpellListRepository();
        private readonly SpellListSpellsRepository _spellListsSpells = new SpellListSpellsRepository();

        public IQueryable<Spell> GetAllSpells()
        {
            return _spells.GetAll();
        }

        public Spell GetSpellBy(int id )
        {
            Expression<Func<Spell, bool>> predicate = (x => x.SpellId == id);
            return _spells.FindBy(predicate).FirstOrDefault();
        }

        public Spell GetSpellBy(string str)
        {
            throw new NotImplementedException();
        }

        public SpellList GetSpellListBy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
