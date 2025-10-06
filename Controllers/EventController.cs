using Microsoft.AspNetCore.Mvc;
using EventManagment.Models;
using EventManagment.Services;

namespace EventManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] Event eventObj)
        {
            if (eventObj == null)
                return BadRequest("El evento no puede ser nulo.");

            var createdEvent = await _eventService.CreateAsync(eventObj);
            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.Id }, createdEvent);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var eventObj = await _eventService.GetByIdAsync(id);

            if (eventObj == null)
                return NotFound();

            return Ok(eventObj);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var deleted = await _eventService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
