using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories
{
    public class SpellListRepository : IRepository<SpellList>
    {
        private readonly IDbContext _context;

        public SpellListRepository(IDbContext c)
        {
            _context = c;
        }

        public IEnumerable<SpellList> GetAll()
        {
            IEnumerable<SpellList> query = _context.SpellLists;
            return query;
        }

        public IEnumerable<SpellList> FindBy(Expression<Func<SpellList, bool>> predicate)
        {

            IEnumerable<SpellList> query = _context.SpellLists.Where(predicate);
            return query;
        }

        public virtual void Add(SpellList entity)
        {
            _context.SpellLists.Add(entity);
        }

        public virtual void Delete(SpellList entity)
        {
            _context.SpellLists.Remove(entity);
        }

        public virtual void Edit(SpellList entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

    }
}
