using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class ProductionBatchService : IService<ProductionBatch>
    {
        private readonly PostgresContext _context;

        public ProductionBatchService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductionBatch>> GetAll()
        {
            return await _context.ProductionBatches.ToListAsync();
        }

        public async Task<ProductionBatch> GetById(int id)
        {
            return await _context.ProductionBatches.FindAsync(id);
        }

        public async Task Create(ProductionBatch entity)
        {
            await _context.ProductionBatches.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProductionBatch entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.ProductionBatches.FindAsync(id);
            if (entity != null)
            {
                _context.ProductionBatches.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
