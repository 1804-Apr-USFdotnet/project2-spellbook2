using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories
{
   public class CharacterRepository: Repository<SpellbookDbContext, Character>
   { }
    
}
