using Spellbook.Models;
using Spellbook.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace Spellbook.Services
{
    public class SpellbookService
    {
        private readonly IMapper _mapper;
        private readonly SpellRepository _spells = new SpellRepository();
        private readonly SpellListRepository _spellLists = new SpellListRepository();
        private readonly SpellListSpellsRepository _spellListsSpells = new SpellListSpellsRepository();

        public List<SpellDTO> GetAllSpells()
        {
            var spellContainer = _spells.GetAll().ToList();
            List<SpellDTO> viewModel = _mapper.Map<List<SpellDTO>>(spellContainer);
            return viewModel;
        }

        public Spell GetSpellBy(int id)
        {
            Expression<Func<Spell, bool>> predicate = (x => x.SpellId == id);
            return _spells.FindBy(predicate).FirstOrDefault();
        }

        public List<Spell> GetSpellBy(string queryString, string filter)
        {
            try
            {
                Expression<Func<Spell, bool>> predicate;
                QueryStringService queryHelper = new QueryStringService(queryString);
                switch (filter)
                {
                    case "levels":
                    {
                        queryHelper.IntPredicate(out predicate);
                        return _spells.FindBy(predicate).ToList();
                    }
                    case "classes":
                    {
                        queryHelper.StringPredicate(filter, out predicate);
                        return _spells.FindBy(predicate).ToList();
                    }
                    case "schools":
                    {
                        queryHelper.StringPredicate(filter, out predicate);
                        return _spells.FindBy(predicate).ToList();
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

        public SpellList GetSpellListBy(int id)
        {
            throw new NotImplementedException();
        }
    }
}

