using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellbookAPI.DataContext;
using SpellbookAPI.Models;

namespace SpellbookAPI.Repositories 
{
    public class SpellRepository : Repository<SpellbookDbContext, Spell>
    {
    }
}
