using Spellbook.Models;
using Spellbook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            Expression<Func<Spell, bool>> predicate;
            QueryStringService queryHelper = new QueryStringService(queryString);
            if (filter == "levels")
            {
                queryHelper.intPredicate(out predicate);
                return _spells.FindBy(predicate).FirstOrDefault();
            }
        }
    }
}
