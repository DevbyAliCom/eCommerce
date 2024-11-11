using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController(IRepositoryBase<Tag> tagRepository)  : ControllerBase
    {
        private IRepositoryBase<Tag> repo = tagRepository;
        [HttpGet]
        public async Task<IActionResult> Get( )
        {
            return Ok(await repo.ListAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var tag = await repo.GetAsync(id);

            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Tag tag)
        {
            repo.Create(tag);

            if (await repo.SaveAsync())
                return CreatedAtAction(nameof(Get), new { id = tag.Id }, tag);

            return BadRequest("Something went wrong");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, Tag tag)
        {
            if (tag == null || tag.Id != id)
            {
                return BadRequest("Tag data is invalid.");
            }

            repo.Update(tag);

            if (await repo.SaveAsync())
                return NoContent();

            return BadRequest("Something went wrong.");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tag = await repo.GetAsync(id);

            if (tag == null)
                return NotFound();

            repo.Delete(tag);

            if (await repo.SaveAsync())
                return NoContent();

            return BadRequest("Something went wrong.");
        }

        public bool Exist(Guid id) => repo.Exist(id);
    }
}
