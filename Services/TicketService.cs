using EventManagment.Models;
using EventManagment.Models.dtos;
using EventManagment.Repositories;

namespace EventManagment.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repo;

        public TicketService(ITicketRepository repo)
        {
            _repo = repo;
        }

        public Ticket Create(CreateTicketDto dto)
        {
            var ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                Notes = dto.Notes
            };
            _repo.Add(ticket);
            return ticket;
        }

        public bool Delete(Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return false;
            _repo.Delete(id);
            return true;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _repo.GetAll();
        }

        public Ticket? GetById(Guid id)
        {
            var ticket = _repo.GetById(id);
            return ticket;
        }
    }
}