using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Spellbook.DataContext;
using Spellbook.Models;

namespace Spellbook.Repositories 
{
    public class SpellRepository : IRepository<Spell>
    {
        private readonly IDBContext _context;

        public SpellRepository(IDBContext c)
        {
            _context = c;
        }

        public IEnumerable<Spell> GetAll()
        {
            IEnumerable<Spell> query = _context.Set<Spell>();
            return query;
        }

        public IEnumerable<Spell> FindBy(Expression<Func<Spell, bool>> predicate)
        {

            IEnumerable<Spell> query = _context.Set<Spell>().Where(predicate);
            return query;
        }

        public virtual void Add(Spell entity)
        {
            _context.Set<Spell>().Add(entity);
        }

        public virtual void Delete(Spell entity)
        {
            _context.Set<Spell>().Remove(entity);
        }

        public virtual void Edit(Spell entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
