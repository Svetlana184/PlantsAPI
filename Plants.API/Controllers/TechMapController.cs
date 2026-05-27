using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plants.API.Models;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TechMapController : ControllerBase
    {
        private readonly IService<TechMap> _service;

        public TechMapController(IService<TechMap> service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<TechMap>>> GetAll()
        {
            var entities = await _service.GetAll();
            return Ok(entities);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<TechMap>> GetById(int id)
        {
            var entity = await _service.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost("post")]
        public async Task<ActionResult<TechMap>> Create([FromBody] TechMap entity)
        {
            await _service.Create(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.IdMap }, entity);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TechMap entity)
        {
            if (entity.IdMap != id) return BadRequest();
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