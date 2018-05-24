using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spellbook.Models;

namespace Spellbook.Tests
{
    public class TestSpellbookDbContext : DbContext
    {
        public TestSpellbookDbContext() : base("name=TestSpellbookContext") {
            
        }

        public DbSet<Spell> Spells { get; set; }
        public DbSet<SpellList> SpellLists { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}
