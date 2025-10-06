using EventManagment.Models;

namespace EventManagment.Repositories
{
    public interface ITicketRepository
    {
        void Add(Ticket ticket);
        void Delete(Guid id);
        IEnumerable<Ticket> GetAll();
        Ticket? GetById(Guid id);
    }
}