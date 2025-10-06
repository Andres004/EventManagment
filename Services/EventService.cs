using EventManagment.Models;
using EventManagment.Repositories;

namespace EventManagment.Services
{
    public class EventService
    {
        private readonly EventRepository _repository;

        public EventService(EventRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Event>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Event?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Event e) => await _repository.AddAsync(e);
        public async Task UpdateAsync(Event e) => await _repository.UpdateAsync(e);
        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}
