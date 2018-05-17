using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
