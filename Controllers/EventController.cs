using EventManagment.Models;
using EventManagment.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly EventService _service;

        public EventController(EventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _service.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var e = await _service.GetByIdAsync(id);
            return e is null ? NotFound() : Ok(e);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event e)
        {
            await _service.AddAsync(e);
            return CreatedAtAction(nameof(GetById), new { id = e.Id }, e);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Event e)
        {
            if (id != e.Id) return BadRequest();
            await _service.UpdateAsync(e);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
