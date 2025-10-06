using EventManagment.Models;

namespace EventManagment.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly List<Ticket> _tickets = new()
        {
            new Ticket { Id = Guid.NewGuid(), Notes = new List<string> { "VIP Access", "Backstage Pass" } },
            new Ticket { Id = Guid.NewGuid(), Notes = new List<string> { "General Admission" } },
            new Ticket { Id = Guid.NewGuid(), Notes = null }
        };

        public void Add(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public void Delete(Guid id)
        {
            _tickets.RemoveAll(t => t.Id == id);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _tickets;
        }

        public Ticket? GetById(Guid id)
        {
            return _tickets.FirstOrDefault(t => t.Id == id);
        }
    }
}