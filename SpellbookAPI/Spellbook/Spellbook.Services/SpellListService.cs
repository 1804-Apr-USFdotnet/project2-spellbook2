using Spellbook.Models;
using System.Linq;

namespace Spellbook.Services
{
    public partial class SpellbookService
    {
        public SpellListDTO GetSpellListBy(int id) {
            var spellbook = _spellLists.FindBy(sl => sl.SpellListId == id).Single();

            return ToSpellListDto(spellbook);
        }

        public void AddSpellList(SpellListDTO spellList) {
            /*
            //automapper couldn't handle this one
            SpellList newSpellList = new SpellList() {
                SpellListId = spellList.SpellListId,
                Name = spellList.Name
            };

            newSpellList.Spells = GetAllSpells().Where(sp => spellList.SpellIds.Contains(sp.SpellId)).ToList();
            */
            _spellLists.Add(ToSpellList(spellList));

            _spellLists.Save();
        }

        public void EditSpellList(SpellListDTO spellList) {
            var spellBook = _spellLists.FindBy(sl => sl.SpellListId == spellList.SpellListId).Single();
            
            var spells = GetAllSpells().Where(sp => spellList.SpellIds.Contains(sp.SpellId)).ToList();

            spellBook.Name = spellList.Name;
            spellBook.Spells = spells;

            _spellLists.Save();
        }

        public void DeleteSpellList(int id) {
            var target = _spellLists.FindBy(sl => sl.SpellListId == id).Single();

            _spellLists.Delete(target);
            
            _spellLists.Save();
        }

        private SpellList ToSpellList(SpellListDTO dto) {
            return new SpellList() {
                SpellListId = dto.SpellListId,
                Name = dto.Name,
                Spells = GetAllSpells().Where(sp => dto.SpellIds.Contains(sp.SpellId)).ToList()
            };
        }

        private SpellListDTO ToSpellListDto(SpellList spellList) {
            return new SpellListDTO() {
                SpellListId = spellList.SpellListId,
                Name = spellList.Name,
                SpellIds = spellList.Spells.Select(sp => sp.SpellId).ToList()
            };
        }
    }
}

