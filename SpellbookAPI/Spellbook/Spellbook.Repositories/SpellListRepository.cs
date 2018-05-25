using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories
{
    public class SpellListRepository : IRepository<SpellList>
    {
        private readonly IDBContext _context;

        public SpellListRepository(IDBContext c)
        {
            _context = c;
        }

        public IEnumerable<SpellList> GetAll()
        {
            IEnumerable<SpellList> query = _context.Set<SpellList>();
            return query;
        }

        public IEnumerable<SpellList> FindBy(Expression<Func<SpellList, bool>> predicate)
        {

            IEnumerable<SpellList> query = _context.Set<SpellList>().Where(predicate);
            return query;
        }

        public virtual void Add(SpellList entity)
        {
            _context.Set<SpellList>().Add(entity);
        }

        public virtual void Delete(SpellList entity)
        {
            _context.Set<SpellList>().Remove(entity);
        }

        public virtual void Edit(SpellList entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

    }
}
