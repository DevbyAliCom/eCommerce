using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;


namespace Infrastructure.Data.Repositories
{
    public class RepositoryBase<T>(StoreContext dbContext) : IRepositoryBase<T> where T : class
    {
        protected readonly StoreContext _dbContext = dbContext;

        public async Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().Where(expression).ToListAsync(cancellationToken);
        }

        public async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public void Create(T entity) => _dbContext.Set<T>().Add(entity);

        public void Update(T entity) => _dbContext.Set<T>().Update(entity);

        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);

        public void Save() => _dbContext.SaveChanges();
    }

}
