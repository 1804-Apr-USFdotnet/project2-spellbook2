using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories
{
   public class CharacterRepository: IRepository<Character>
   {
       private readonly IDBContext _context;

       public CharacterRepository(IDBContext c)
       {
           _context = c;
       }

       public IEnumerable<Character> GetAll()
       {
           IEnumerable<Character> query = _context.Set<Character>();
           return query;
       }

       public IEnumerable<Character> FindBy(Expression<Func<Character, bool>> predicate)
       {

           IEnumerable<Character> query = _context.Set<Character>().Where(predicate);
           return query;
       }

       public virtual void Add(Character entity)
       {
           _context.Set<Character>().Add(entity);
       }

       public virtual void Delete(Character entity)
       {
           _context.Set<Character>().Remove(entity);
       }

       public virtual void Edit(Character entity)
       {
           _context.Entry(entity).State = EntityState.Modified;
       }

       public virtual void Save()
       {
           _context.SaveChanges();
       }
    }    
}
