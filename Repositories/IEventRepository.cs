using EventManagment.Models;

namespace EventManagment.Repositories
{
    public interface IEventRepository
    {
        Task<Event> CreateAsync(Event eventObj);
        Task<Event?> GetByIdAsync(Guid id);
        Task<IEnumerable<Event>> GetAllAsync();
        Task<bool> DeleteAsync(Guid id);
    }
}
