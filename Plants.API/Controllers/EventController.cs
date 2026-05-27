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
    public class EventController : ControllerBase
    {
        private readonly IService<Event> _eventService;

        public EventController(IService<Event> eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            var events = await _eventService.GetAll();
            return Ok(events);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            var eventEntity = await _eventService.GetById(id);
            if (eventEntity == null)
            {
                return NotFound();
            }
            return Ok(eventEntity);
        }

        [HttpPost("post")]
        public async Task<ActionResult<Event>> CreateEvent([FromBody] Event eventEntity)
        {
            await _eventService.Create(eventEntity);
            return CreatedAtAction(nameof(GetEventById), new { id = eventEntity.IdEvent }, eventEntity);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] Event eventEntity)
        {
            if (eventEntity.IdEvent != id)
            {
                return BadRequest("ID в пути и ID в теле запроса не совпадают");
            }

            var existingEvent = await _eventService.GetById(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            await _eventService.Update(eventEntity);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var existingEvent = await _eventService.GetById(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            await _eventService.Delete(id);
            return NoContent();
        }
    }
}