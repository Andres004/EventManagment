using EventManagment.Models;
using EventManagment.Repositories;

namespace EventManagment.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<Event> CreateAsync(Event eventObj)
        {
            return await _repository.CreateAsync(eventObj);
        }

        public async Task<Event?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
