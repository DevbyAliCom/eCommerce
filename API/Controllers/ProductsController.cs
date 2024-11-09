using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductRepository productRepository) : ControllerBase
    {
        private readonly IProductRepository _productRepository = productRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAsync(cancellationToken);
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(id, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //[HttpGet("category/{categoryId:guid}")]
        //public async Task<IActionResult> GetProductsByCategory(Guid categoryId, CancellationToken cancellationToken)
        //{
        //    var products = await _productRepository.GetProductsByCategoryAsync(categoryId, cancellationToken);
        //    return Ok(products);
        //}

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            _productRepository.Create(product);
            _productRepository.Save();
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] Product product)
        {
            if (product == null || product.Id != id)
            {
                return BadRequest("Product data is invalid.");
            }

            var existingProduct = _productRepository.GetAsync(id, CancellationToken.None).Result;
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productRepository.Update(product);
            _productRepository.Save();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _productRepository.GetAsync(id, CancellationToken.None).Result;
            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Delete(product);
            _productRepository.Save();
            return NoContent();
        }
    }
}
