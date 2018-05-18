using System.Data.Entity;
using SpellbookAPI.Models;

namespace SpellbookAPI.DataContext
{
    public class SpellbookDbContext : DbContext
    {
        public SpellbookDbContext() : base("name=SpellBookContext")
        {
            Database.SetInitializer<SpellbookDbContext>(new DbInit());
        }

        public DbSet<Spell> Spells { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}
