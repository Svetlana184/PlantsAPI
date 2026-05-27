using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class BatchRawMaterialService : IService<BatchRawMaterial>
    {
        private readonly PostgresContext _context;

        public BatchRawMaterialService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BatchRawMaterial>> GetAll()
        {
            return await _context.BatchRawMaterials.ToListAsync();
        }

        public async Task<BatchRawMaterial> GetById(int id)
        {
            return await _context.BatchRawMaterials.FindAsync(id);
        }

        public async Task Create(BatchRawMaterial entity)
        {
            await _context.BatchRawMaterials.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(BatchRawMaterial entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.BatchRawMaterials.FindAsync(id);
            if (entity != null)
            {
                _context.BatchRawMaterials.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
