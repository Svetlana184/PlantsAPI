using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class TechMapService : IService<TechMap>
    {
        private readonly PostgresContext _context;

        public TechMapService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechMap>> GetAll()
        {
            return await _context.TechMaps.ToListAsync();
        }

        public async Task<TechMap> GetById(int id)
        {
            return await _context.TechMaps.FindAsync(id);
        }

        public async Task Create(TechMap entity)
        {
            await _context.TechMaps.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TechMap entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.TechMaps.FindAsync(id);
            if (entity != null)
            {
                _context.TechMaps.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
