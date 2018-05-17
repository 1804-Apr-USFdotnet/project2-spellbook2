using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbook.DataContext
{
    class DbInit : CreateDatabaseIfNotExists<spellbookDbContext>
    {
        protected override void Seed(spellbookDbContext context)
        {
            base.Seed(context);
            context.SaveChanges();
        }
    }
}

