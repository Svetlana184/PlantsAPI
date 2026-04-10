using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class, new()
    {
        private readonly IService<T> _service;
        public GenericController(IService<T> service) => _service = service;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => Ok(await _service.GetById(id));
        [HttpPost] public async Task<IActionResult> Post([FromBody] T e) { await _service.Create(e); return Ok(e); }
        [HttpPut("{id}")] public async Task<IActionResult> Put([FromBody] T e) { await _service.Update(e); return Ok(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.Delete(id); return Ok(); }
    }
}