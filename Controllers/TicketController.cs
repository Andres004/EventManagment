using EventManagment.Models.dtos;
using EventManagment.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketsController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetOne(Guid id)
        {
            var ticket = _service.GetById(id);
            return ticket == null
                ? NotFound(new { error = "Ticket not found", status = 404 })
                : Ok(ticket);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTicketDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var ticket = _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = ticket.Id }, ticket);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var success = _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Ticket not found", status = 404 });
        }
    }
}