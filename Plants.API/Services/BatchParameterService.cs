using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class BatchParameterService : IService<BatchParameter>
    {
        private readonly PostgresContext _context;

        public BatchParameterService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BatchParameter>> GetAll()
        {
            return await _context.BatchParameters.ToListAsync();
        }

        public async Task<BatchParameter> GetById(int id)
        {
            return await _context.BatchParameters.FindAsync(id);
        }

        public async Task Create(BatchParameter entity)
        {
            await _context.BatchParameters.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(BatchParameter entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.BatchParameters.FindAsync(id);
            if (entity != null)
            {
                _context.BatchParameters.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
