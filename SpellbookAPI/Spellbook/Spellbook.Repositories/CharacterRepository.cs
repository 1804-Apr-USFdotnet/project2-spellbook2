using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories
{
   public class CharacterRepository: IRepository<Character>
   {
       private readonly IDbContext _context;

       public CharacterRepository(IDbContext c)
       {
           _context = c;
       }

       public IEnumerable<Character> GetAll()
       {
           IEnumerable<Character> query = _context.Characters;
           return query;
       }

       public IEnumerable<Character> FindBy(Expression<Func<Character, bool>> predicate)
       {

           IEnumerable<Character> query = _context.Characters.Where(predicate);
           return query;
       }

       public virtual void Add(Character entity)
       {
           _context.Characters.Add(entity);
       }

       public virtual void Delete(Character entity)
       {
           _context.Characters.Remove(entity);
       }

       public virtual void Edit(Character entity)
       {
           throw new NotImplementedException();
       }

       public virtual void Save()
       {
           _context.SaveChanges();
       }
    }    
}
