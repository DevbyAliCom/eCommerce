using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {

        Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task<T?> GetAsync(Guid id, CancellationToken cancellationToken);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();

    }
}
