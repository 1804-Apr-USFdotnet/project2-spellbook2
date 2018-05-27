using System.Collections.Generic;
using System.Linq;
using Spellbook.Models;

namespace Spellbook.Services
{
    public partial class SpellbookService
    {
        public List<CharacterDTO> GetAllCharacters()
        {
            var characters = _characters.GetAll().ToList();

            var characterDtos = new List<CharacterDTO>();

            foreach (Character character in characters) {
                characterDtos.Add(ToCharacterDto(character));
            }

            return characterDtos;
        }

        public CharacterDTO GetCharacterBy(int id) {
            var character = _characters.FindBy(ch => ch.CharacterId == id).Single();

            return ToCharacterDto(character);
        }

        public void AddCharacter(CharacterDTO c)
        {
            _characters.Add(ToCharacter(c));
            _characters.Save();
        }

        public void EditCharacter(CharacterDTO c) {
            var character = _characters.FindBy(ch => ch.CharacterId == c.CharacterId).Single();

            character.Name = c.Name;
            character.Level = c.Level;
            character.Spellbook = ToSpellList(c.Spellbook);

            _characters.Save();
        }

        public void DeleteCharacter(int id) {
            var target = _characters.FindBy(ch => ch.CharacterId == id).Single();

            _characters.Delete(target);
            _characters.Save();
        }

        private CharacterDTO ToCharacterDto(Character character) {
            return new CharacterDTO() {
                CharacterId = character.CharacterId,
                Name = character.Name,
                Level = character.Level,
                Spellbook = ToSpellListDto(character.Spellbook)
            };
        }

        private Character ToCharacter(CharacterDTO dto) {
            return new Character() {
                CharacterId = dto.CharacterId,
                Name = dto.Name,
                Level = dto.Level,
                Spellbook = ToSpellList(dto.Spellbook)
            };
        }
    }
}
