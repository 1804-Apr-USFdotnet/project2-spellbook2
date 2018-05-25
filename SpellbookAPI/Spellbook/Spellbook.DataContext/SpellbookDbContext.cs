using System.Data.Entity;
using Spellbook.Models;

namespace Spellbook.DataContext
{
    public class SpellbookDbContext : DbContext, IDbContext
    {
        public SpellbookDbContext() : base("name=SpellBookContext")
        {
            Database.SetInitializer<SpellbookDbContext>(new DbInit());
        }

        public DbSet<Spell> Spells { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<SpellList> SpellLists { get; set; }
    }
}
