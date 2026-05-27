using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class RawMaterialService : IService<RawMaterial>
    {
        private readonly PostgresContext _context;

        public RawMaterialService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RawMaterial>> GetAll()
        {
            return await _context.RawMaterials.ToListAsync();
        }

        public async Task<RawMaterial> GetById(int id)
        {
            return await _context.RawMaterials.FindAsync(id);
        }

        public async Task Create(RawMaterial entity)
        {
            await _context.RawMaterials.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(RawMaterial entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.RawMaterials.FindAsync(id);
            if (entity != null)
            {
                _context.RawMaterials.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
