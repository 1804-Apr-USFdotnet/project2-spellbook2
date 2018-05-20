using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories 
{
    public class SpellRepository : Repository<SpellbookDbContext, Spell>
    {
    }
}
