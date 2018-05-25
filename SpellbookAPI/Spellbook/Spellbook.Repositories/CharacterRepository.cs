using System;
using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories
{
   public class CharacterRepository: ARepository<SpellbookDbContext, Character>
   {
       public CharacterRepository(SpellbookDbContext context) : base(context) { }
   }    
}
