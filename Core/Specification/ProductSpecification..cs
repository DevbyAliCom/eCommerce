using Core.Entities;
using System.Linq;


namespace Core.Specification
{
    public class ProductSpecification : SpecificationBase<Product>
    {
        public ProductSpecification(ProductSpecParams specParams) : base(
         x => (
             (!specParams.CategoryId.HasValue || x.CategoryId == specParams.CategoryId) &&
             (specParams.Tags.Count == 0 || specParams.Tags.Any(tag => x.Tags.Any(t => t.Tag.Id == tag)))
         )
     )
        {
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            switch (specParams.Sort)
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
