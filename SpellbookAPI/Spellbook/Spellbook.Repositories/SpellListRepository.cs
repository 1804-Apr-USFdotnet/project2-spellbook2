using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories
{
    public class SpellListRepository : ARepository<SpellbookDbContext, SpellList>
    {
        public SpellListRepository(SpellbookDbContext context) : base(context) { }
    }
}
