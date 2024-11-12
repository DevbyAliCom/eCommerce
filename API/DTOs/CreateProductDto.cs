namespace API.DTOs
{
    using FluentValidation;
    public class CreateProductDto
    {

        public  string Name { get; set; } =string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public Guid CategoryId { get; set; }
        public string? SKU { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int QtyInStock { get; set; }
        public List<Guid> TagIds { get; set; } = new List<Guid>();
    }
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a name");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please specify a description");
            RuleFor(x => x.Price).GreaterThan(0.01m).WithMessage("Price must be greater than 0.01.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required.");

        }
    }
}
