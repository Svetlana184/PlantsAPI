using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class RawMaterialBatchService : IService<RawMaterialBatch>
    {
        private readonly PostgresContext _context;

        public RawMaterialBatchService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RawMaterialBatch>> GetAll()
        {
            return await _context.RawMaterialBatches.ToListAsync();
        }

        public async Task<RawMaterialBatch> GetById(int id)
        {
            return await _context.RawMaterialBatches.FindAsync(id);
        }

        public async Task Create(RawMaterialBatch entity)
        {
            await _context.RawMaterialBatches.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(RawMaterialBatch entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.RawMaterialBatches.FindAsync(id);
            if (entity != null)
            {
                _context.RawMaterialBatches.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
