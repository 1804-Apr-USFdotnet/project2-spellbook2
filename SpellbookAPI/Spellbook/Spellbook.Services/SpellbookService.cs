using System.Data.Entity;
using Spellbook.Models;
using Spellbook.Repositories;

namespace Spellbook.Services
{
    public partial class SpellbookService {
        private readonly SpellRepository _spells;
        private readonly SpellListRepository _spellLists;
        private readonly CharacterRepository _characters;

        public SpellbookService() {
            _spells = new SpellRepository();
            _spellLists = new SpellListRepository();
            _characters = new CharacterRepository();
        }
    }
}
