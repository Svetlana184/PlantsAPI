using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class BatchStepService : IService<BatchStep>
    {
        private readonly PostgresContext _context;

        public BatchStepService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BatchStep>> GetAll()
        {
            return await _context.BatchSteps.ToListAsync();
        }

        public async Task<BatchStep> GetById(int id)
        {
            return await _context.BatchSteps.FindAsync(id);
        }

        public async Task Create(BatchStep entity)
        {
            await _context.BatchSteps.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(BatchStep entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.BatchSteps.FindAsync(id);
            if (entity != null)
            {
                _context.BatchSteps.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
