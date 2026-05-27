using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class DeviationService : IService<Deviation>
    {
        private readonly PostgresContext _context;

        public DeviationService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Deviation>> GetAll()
        {
            return await _context.Deviations.ToListAsync();
        }

        public async Task<Deviation> GetById(int id)
        {
            return await _context.Deviations.FindAsync(id);
        }

        public async Task Create(Deviation entity)
        {
            await _context.Deviations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Deviation entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Deviations.FindAsync(id);
            if (entity != null)
            {
                _context.Deviations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
