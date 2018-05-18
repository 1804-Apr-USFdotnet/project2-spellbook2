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
        private readonly CharacterRepository _characters = new CharacterRepository(); // I think??

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

        public Character GetCharacterBy(int id) //Caitlin Was Here
        {
            Expression<Func<Character, bool>> predicate = (x => x.CharacterId == id);
            return _characters.FindBy(predicate).FirstOrDefault();
        }
        public Character GetCharacterBy(string str)
        {
            throw new NotImplementedException();
        }
    }
}
