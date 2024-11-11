using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Infrastructure.Data.Repositories;
using Core.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IRepositoryBase<Category> categoryRepository) : ControllerBase
    {
        private IRepositoryBase<Category> repo = categoryRepository;

        [HttpGet]
        public async Task<IActionResult> Get( )
        {
            return Ok(await repo.ListAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await repo.GetAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            repo.Create(category);

            if (await repo.SaveAsync())
                return CreatedAtAction(nameof(Get), new { id = category.Id }, category);

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, Category category)
        {
            if (category == null || category.Id != id)
            {
                return BadRequest("Category data is invalid.");
            }

            repo.Update(category);

            if (await repo.SaveAsync())
                return NoContent();

            return BadRequest("Something went wrong.");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await repo.GetAsync(id);

            if (category == null)
                return NotFound();

            repo.Delete(category);

            if (await repo.SaveAsync())
                return NoContent();

            return BadRequest("Something went wrong.");
        }

        public bool Exist(Guid id) => repo.Exist(id);
    }
}
