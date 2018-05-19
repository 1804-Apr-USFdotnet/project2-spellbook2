using Spellbook.Models;
using Spellbook.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Spellbook.Services
{
    public class SpellbookService
    {
        private readonly SpellRepository _spells = new SpellRepository();

        public IQueryable<Spell> GetAllSpells()
        {
            return _spells.GetAll();
        }

        public Spell GetSpellBy(int id)
        {
            Expression<Func<Spell, bool>> predicate = (x => x.SpellId == id);
            return _spells.FindBy(predicate).FirstOrDefault();
        }

        public IEnumerable<Spell> GetSpellBy(string queryString, string filter)
        {
            Expression<Func<Spell, bool>> predicate;
            QueryStringService queryHelper = new QueryStringService(queryString);

            try
            {
                switch (filter)
                {
                    case "levels":
                    {
                        queryHelper.IntPredicate(out predicate);
                        return _spells.FindBy(predicate);
                    }
                    case "classes":
                    {
                        queryHelper.StringPredicate(filter, out predicate);
                        return _spells.FindBy(predicate);
                    }
                    case "schools":
                    {
                        queryHelper.StringPredicate(filter, out predicate);
                        return _spells.FindBy(predicate);
                    }
                    default:
                    {
                        throw new SystemException();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}

