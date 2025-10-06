using EventManagment.Models;

namespace EventManagment.Services
{
    public interface IEventService
    {
        Task<Event> CreateAsync(Event eventObj);
        Task<Event?> GetByIdAsync(Guid id);
        Task<IEnumerable<Event>> GetAllAsync();
        Task<bool> DeleteAsync(Guid id);
    }
}
