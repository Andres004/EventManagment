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

        public async Task<List<Event>> GetAllAsync() => await _context.Events.ToListAsync();

        public async Task<Event?> GetByIdAsync(Guid id) => await _context.Events.FindAsync(id);

        public async Task AddAsync(Event e)
        {
            _context.Events.Add(e);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Event e)
        {
            _context.Events.Update(e);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev != null)
            {
                _context.Events.Remove(ev);
                await _context.SaveChangesAsync();
            }
        }
    }
}

