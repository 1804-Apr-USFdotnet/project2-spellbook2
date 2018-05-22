using Spellbook.Models;
using Spellbook.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace Spellbook.Services
{
    public class SpellbookService
    {
        private readonly SpellRepository _spells = new SpellRepository();

        private readonly CharacterRepository _characters = new CharacterRepository(); 
        private readonly SpellListRepository _spellLists = new SpellListRepository();
        private readonly SpellListSpellsRepository _spellListsSpells = new SpellListSpellsRepository();


        public List<SpellDTO> GetAllSpells()
        {
            var spellContainer = _spells.GetAll().ToList();
            List<SpellDTO> viewModel = Mapper.Map<List<SpellDTO>>(spellContainer);
            return viewModel;
        }

        public SpellDTO GetSpellBy(int id)
        {
            Expression<Func<Spell, bool>> predicate = (x => x.SpellId == id);
            var spell = _spells.FindBy(predicate).FirstOrDefault();
            var spelldto = Mapper.Map<SpellDTO>(spell);
            return spelldto;
        }

        public List<SpellDTO> GetSpellBy(string queryString, string filter)
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
                            var spellContainer = _spells.FindBy(predicate).ToList();
                            return Mapper.Map<List<SpellDTO>>(spellContainer);
                        }
                    case "classes":
                        {
                            queryHelper.StringPredicate(filter, out predicate);
                            var spellContainer = _spells.FindBy(predicate).ToList();
                            return Mapper.Map<List<SpellDTO>>(spellContainer);
                        }
                    case "schools":
                        {
                            queryHelper.StringPredicate(filter, out predicate);
                            var spellContainer = _spells.FindBy(predicate).ToList();
                            return Mapper.Map<List<SpellDTO>>(spellContainer);
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

        public Character GetCharacterBy(int id)
        {
            Expression<Func<Character, bool>> predicate = (x => x.CharacterId == id);
            return _characters.FindBy(predicate).FirstOrDefault();
        }

        public void AddCharacter(Character c)
        {
            _characters.Add(c);
        }

        public void DeleteCharacter(Character c)
        {
            _characters.Delete(c);
        }

        public void EditCharacter(Character c)
        {
            _characters.Edit(c);
        }

    }
}

