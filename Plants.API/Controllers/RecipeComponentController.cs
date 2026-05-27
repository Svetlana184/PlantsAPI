using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plants.API.Models;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeComponentController : ControllerBase
    {
        private readonly IService<RecipeComponent> _service;

        public RecipeComponentController(IService<RecipeComponent> service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<RecipeComponent>>> GetAll()
        {
            var entities = await _service.GetAll();
            return Ok(entities);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<RecipeComponent>> GetById(int id)
        {
            var entity = await _service.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost("post")]
        public async Task<ActionResult<RecipeComponent>> Create([FromBody] RecipeComponent entity)
        {
            await _service.Create(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.IdRecord }, entity);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] RecipeComponent entity)
        {
            if (entity.IdRecord != id) return BadRequest();
            await _service.Update(entity);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}