using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IRepositoryBase<Product> productRepository) : ControllerBase
    {
        private readonly IRepositoryBase<Product> repo = productRepository;

        [HttpGet]
        public async Task<IActionResult> Get(Guid? categoryId,List<string>? tags, string? sort)
        {
            var spec = new ProductSpecification(categoryId,tags,sort);
            var products= await repo.ListAsync(spec);
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await repo.GetAsync(id);

            if (product == null)
                 return NotFound();
           
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            repo.Create(product);

            if (await repo.SaveAsync())
               return CreatedAtAction(nameof(Get), new { id = product.Id }, product);

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, Product product)
        {
            if (product == null || product.Id != id)
            {
                return BadRequest("Product data is invalid.");
            }
        
            repo.Update(product);

            if (await repo.SaveAsync())
                return NoContent();

            return BadRequest("Something went wrong.");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await repo.GetAsync(id);

            if (product == null)
                return NotFound();
            
            repo.Delete(product);

            if (await repo.SaveAsync())
                return NoContent();

            return BadRequest("Something went wrong.");
        }

        public bool Exist(Guid id) => repo.Exist(id);

    }
}
