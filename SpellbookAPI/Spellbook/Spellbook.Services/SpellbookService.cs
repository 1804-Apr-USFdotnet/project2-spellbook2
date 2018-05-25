using System.Data.Entity;
using Spellbook.DataContext;
using Spellbook.Models;
using Spellbook.Repositories;

namespace Spellbook.Services
{
    public partial class SpellbookService {
        private readonly SpellRepository _spells;
        private readonly SpellListRepository _spellLists;
        private readonly CharacterRepository _characters;

        public SpellbookService(SpellbookDbContext context) {
            _spells = new SpellRepository(context);
            _spellLists = new SpellListRepository(context);
            _characters = new CharacterRepository(context);
        }
    }
}
