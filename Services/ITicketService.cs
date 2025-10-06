using EventManagment.Models;
using EventManagment.Models.dtos;

namespace EventManagment.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAll();
        Ticket? GetById(Guid id);
        Ticket Create(CreateTicketDto dto);
        bool Delete(Guid id);
    }
}