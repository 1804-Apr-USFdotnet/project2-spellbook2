using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbook.DataContext
{
    class DbInit : CreateDatabaseIfNotExists<SpellbookDbContext>
    {
        protected override void Seed(SpellbookDbContext context)
        {
            base.Seed(context);
            context.SaveChanges();
        }
    }
}

