
using System.Linq.Expressions;


namespace Core.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>>? Criteria { get; }
        Expression<Func<T, object>>? OrderBy { get; }
        Expression<Func<T, object>>? OrderByDesc { get; }
        public int Take { get;}
        public int Skip { get;}
        public bool PagingEnabled { get;}
        IQueryable<T> ApplyCriteria(IQueryable<T> query);

    }
}
