using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(StoreContext context, ILogger<ProductsController> logger) : ControllerBase
    {

        private StoreContext context { get; } = context;
        private readonly ILogger<ProductsController> _logger = logger;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAsync() => await context.Products.ToListAsync();

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Product>> GetAsync(Guid id)
        {
           var product = await context.Products.FindAsync(id); 
           if (product == null)  return NotFound();
           return product;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateAsync(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }
        [HttpPut ("{id:Guid}")]
        public async Task<ActionResult> UpdateAsync (Guid id,Product product)
        {
            if ( product.Id != id ||  !ProductExists(id))
                return BadRequest("Cannot update product");
         
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var product = await context.Products.FindAsync(id);
            if (product ==null) return NotFound();
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductExists(Guid id)
        {
            return context.Products.Any(x => x.Id==id);
        }
    }
}
