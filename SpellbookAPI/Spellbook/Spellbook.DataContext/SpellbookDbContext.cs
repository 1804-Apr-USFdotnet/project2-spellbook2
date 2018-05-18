using System.Data.Entity;
using Spellbook.Models;

namespace Spellbook.DataContext
{
    public class SpellbookDbContext : DbContext
    {
        public SpellbookDbContext() : base("name=SpellBookContext")
        {
            Database.SetInitializer<SpellbookDbContext>(new DbInit());
        }

        public DbSet<Spell> Spells { get; set; }
    }
}
