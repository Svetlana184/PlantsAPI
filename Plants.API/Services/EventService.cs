using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class EventService : IService<Event>
    {
        private readonly PostgresContext _context;

        public EventService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events
                .Include(e => e.IdProductionBatchNavigation)
                .Include(e => e.IdUserNavigation)
                .ToListAsync();
        }

        public async Task<Event> GetById(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.IdEvent == id);
        }

        public async Task Create(Event entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            await _context.Events.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Event entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Events.FindAsync(id);
            if (entity != null)
            {
                _context.Events.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
