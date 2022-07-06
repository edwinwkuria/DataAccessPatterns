using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyShop.Infrastructure.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ShoppingContext _context;

        public GenericRepository(ShoppingContext context)
        {
            this._context = context;    
        }
        public virtual T Add(T entity)
        {
           return  _context.Add(entity).Entity;
        }

        public virtual T Delete(T entity)
        {
            return _context.Remove(entity).Entity;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                     .AsQueryable()
                     .Where(predicate)
                     .ToList();
        }

        public virtual T Get(Guid id)
        {
            return _context.Find<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>()
                        .ToList();
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }
    }
}
