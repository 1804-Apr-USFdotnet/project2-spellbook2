using System.Data.Entity;
using Spellbook.Models;

namespace Spellbook.DataContext
{
    public class spellbookDbContext : DbContext
    {
        public spellbookDbContext() : base("name=SpellBookContext")
        {
            Database.SetInitializer<spellbookDbContext>(new DbInit());
        }

        public DbSet<Spell> Spells { get; set; }
    }
}
