using System.Data.Entity;
using Spellbook.Models;

namespace Spellbook.DataContext
{
    public interface IDbContext {
        int SaveChanges();

        DbSet<Spell> Spells { get; set; }
        DbSet<Character> Characters { get; set; }
        DbSet<SpellList> SpellLists { get; set; }
    }
}
