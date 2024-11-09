using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {


        // Define additional methods specific to products if necessary
        IEnumerable<Product> GetProductsByCategory(Guid categoryId);
    }
}
