using System;
using System.Linq;
using SpellbookAPI.DataContext;
using System.Data.Entity;
using System.Linq.Expressions;
using SpellbookAPI.Models;

namespace SpellbookAPI.Repositories
{
    public abstract class ARepository<C, T> :
        IRepository<T> where T : class where C : SpellbookDbContext, new()
    {
        private readonly C _context = new C();

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
