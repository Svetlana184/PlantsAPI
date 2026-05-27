using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plants.API.Models;
using Plants.API.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Plants.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BatchStepController : ControllerBase
    {
        private readonly IService<BatchStep> _service;

        public BatchStepController(IService<BatchStep> service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<BatchStep>>> GetAll()
        {
            var entities = await _service.GetAll();
            return Ok(entities);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<BatchStep>> GetById(int id)
        {
            var entity = await _service.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost("post")]
        public async Task<ActionResult<BatchStep>> Create([FromBody] BatchStep entity)
        {
            await _service.Create(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.IdExecution }, entity);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BatchStep entity)
        {
            if (entity.IdExecution != id) return BadRequest();
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