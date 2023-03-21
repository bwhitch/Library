using Library.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LibraryDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(LibraryDbContext context)
        {
            _context = context ?? throw new ArgumentException("context");
            _dbSet = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }

        public virtual void Delete(Guid id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
                return; //assume it's already been deleted
            else
                Delete(entity);
        }

        public virtual T Get(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> GetAsync(
            Expression<Func<T, bool>> match,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = this._dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.SingleOrDefaultAsync(match).ConfigureAwait(false);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual async Task<ICollection<T>> GetAllAsync(
            Expression<Func<T, bool>> match = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = this._dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (match != null)
            {
                query = query.Where(match);
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);


            }

            return query;
        }

        public virtual void Update(T entity)
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
                _dbSet.Attach(entity);

            if (entry.State != EntityState.Added)
                entry.State = EntityState.Modified;
        }

        public bool Exists(Expression<Func<T, bool>> match)
        {
            return _dbSet.Any(match);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> match)
        {
            return await _dbSet.AnyAsync(match);
        }

       IEnumerable<T> IRepository<T>.GetAll(Expression<Func<T, bool>> predicate, string? includeProperties)
        {
            IQueryable<T> query = _dbSet;
            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if(includeProperties != null)
            {
                foreach(var item in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }

       T IRepository<T>.GetT(Expression<Func<T, bool>> predicate, string? includeProperties)
        {
            IQueryable<T> query = _dbSet;
            query= query.Where(predicate);
            if(includeProperties != null)
            {
                foreach(var item in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }
    }
}
