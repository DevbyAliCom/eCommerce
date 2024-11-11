using Core.Entities;


namespace Core.Specification
{
    public class ProductSpecification : SpecificationBase<Product>
    {
        public ProductSpecification(Guid? categoryId, string? sort) : base(
         x => (!categoryId.HasValue || x.CategoryId == categoryId)
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
