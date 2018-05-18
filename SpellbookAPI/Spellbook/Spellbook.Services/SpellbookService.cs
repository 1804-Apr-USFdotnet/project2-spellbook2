using System;
using System.Collections.Generic;
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

        public IQueryable<Spell> GetAllSpells()
        {
            return _spells.GetAll();
        }

        public Spell GetSpellBy(int id )
        {
            Expression<Func<Spell, bool>> predicate = (x => x.SpellId == id);
            return _spells.FindBy(predicate).FirstOrDefault();
        }

        public Spell GetSpellBy(string queryString, string filter)
        {
            throw new NotImplementedException();
            HashSet<int> levels;
            Expression<Func<Spell, bool>> predicate = (x => levels.Contains(x.Level));
        }
    }
}
