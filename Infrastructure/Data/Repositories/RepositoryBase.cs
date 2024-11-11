using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using Core.Entities;


namespace Infrastructure.Data.Repositories
{
    public class RepositoryBase<T>(StoreContext context) : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly StoreContext context = context;

        public async Task<IReadOnlyList<T>> ListAllAsync() => await context.Set<T>().ToListAsync();

        public async Task<T?> GetAsync(Guid id) => await context.Set<T>().FindAsync(id);
        
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec) 
            => await ApplySpecification(spec).ToListAsync();
        
        public async Task<T?> GetWithSpecAsync(ISpecification<T> spec)
           => await ApplySpecification(spec).FirstOrDefaultAsync();

        public void Create(T entity) => context.Set<T>().Add(entity);

        public void Update(T entity) => context.Set<T>().Update(entity);

        public void Delete(T entity) => context.Set<T>().Remove(entity);

        public async Task<bool> SaveAsync() => await context.SaveChangesAsync() > 0;

        public bool Exist(Guid id) =>context.Set<T>().Any(x=>x.Id==id);

       private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), spec);
        }

      
    }

}
