using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Spellbook.Models;
using Spellbook.Repositories;

namespace Spellbook.Services
{
    public partial class SpellbookService
    {
        public List<CharacterDTO> GetAllCharacters()
        {
            var characters = _characters.GetAll().ToList();
            return Mapper.Map<List<CharacterDTO>>(characters);
        }

        public CharacterDTO GetCharacterBy(int id)
        {
            Expression<Func<Character, bool>> predicate = (x => x.CharacterId == id);
            var character =  _characters.FindBy(predicate).FirstOrDefault();
            return Mapper.Map<CharacterDTO>(character);
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
