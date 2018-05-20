using System;
using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories
{
   public class CharacterRepository: ARepository<SpellbookDbContext, Character>
   {
   }    
}
