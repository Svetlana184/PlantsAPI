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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabResultController : ControllerBase
    {
        private readonly IService<LabResult> _service;

        public LabResultController(IService<LabResult> service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<LabResult>>> GetAll()
        {
            var entities = await _service.GetAll();
            return Ok(entities);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<LabResult>> GetById(int id)
        {
            var entity = await _service.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost("post")]
        public async Task<ActionResult<LabResult>> Create([FromBody] LabResult entity)
        {
            await _service.Create(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.IdResult }, entity);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] LabResult entity)
        {
            if (entity.IdResult != id) return BadRequest();
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