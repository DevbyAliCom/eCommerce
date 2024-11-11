using Core.Entities;
using System.Linq;


namespace Core.Specification
{
    public class ProductSpecification : SpecificationBase<Product>
    {
        public ProductSpecification(Guid? categoryId, IList<string>? tags, string? sort) : base(
         x => (
             (!categoryId.HasValue || x.CategoryId == categoryId) &&
             (tags == null || tags.Any(tag => x.Tags.Any(t => t.Tag.Name == tag)))
         )
     )
        {
            switch (sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(x => x.Price);
                    break;
                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
        }
    }
}
