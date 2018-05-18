using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories // make a character model and making a character repository reference more or less
{
    public class SpellRepository : Repository<SpellbookDbContext, Spell>
    {
    }
}
