using EventManagment.Data;
using EventManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagment.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Event> CreateAsync(Event eventObj)
        {
            _context.Set<Event>().Add(eventObj);
            await _context.SaveChangesAsync();
            return eventObj;
        }

        public async Task<Event?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Event>().FindAsync(id);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Set<Event>().ToListAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var eventObj = await _context.Set<Event>().FindAsync(id);
            if (eventObj == null)
                return false;

            _context.Set<Event>().Remove(eventObj);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
