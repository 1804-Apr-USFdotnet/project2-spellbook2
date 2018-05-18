using System;
using SpellbookAPI.DataContext;
using SpellbookAPI.Models;

namespace SpellbookAPI.Repositories
{
   public class CharacterRepository: Repository<SpellbookDbContext, Character>
   {
   }    
}
