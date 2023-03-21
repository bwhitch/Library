using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        //x=>x.id==id, _context.product.include("products, tags").tolist();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null, string? includeProperties = null);

        T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null);
        void Add(T entity);

        void Delete(T entity);

        void Delete(Guid id);

        T Get(Guid id);

        Task<T> GetAsync(Guid id);

        Task<T> GetAsync(
            Expression<Func<T, bool>> match,
            params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll();

        Task<ICollection<T>> GetAllAsync(
            Expression<Func<T, bool>> match = null,
            params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        void Update(T entity);

        bool Exists(Expression<Func<T, bool>> match);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> match);
    }
}
