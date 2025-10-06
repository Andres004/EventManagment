using EventManagment.Models;

namespace EventManagment.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(Guid id);
        Task AddAsync(Event e);
        Task UpdateAsync(Event e);
        Task DeleteAsync(Guid id);
    }
}
