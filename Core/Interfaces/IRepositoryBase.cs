using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {

        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T?> GetAsync(Guid id);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T>spec);
        Task<T?> GetWithSpecAsync(ISpecification<T>spec);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveAsync();
        bool Exist(Guid id);
    }
}
