using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(StoreContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Product> GetProductsByCategory(Guid categoryId)
        {
            // Use the _dbContext from RepositoryBase
            return _dbContext.Set<Product>().Where(p => p.Id == categoryId).ToList();
        }
    }

}
