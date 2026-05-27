using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class LabResultService : IService<LabResult>
    {
        private readonly PostgresContext _context;

        public LabResultService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LabResult>> GetAll()
        {
            return await _context.LabResults.ToListAsync();
        }

        public async Task<LabResult> GetById(int id)
        {
            return await _context.LabResults.FindAsync(id);
        }

        public async Task Create(LabResult entity)
        {
            await _context.LabResults.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(LabResult entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.LabResults.FindAsync(id);
            if (entity != null)
            {
                _context.LabResults.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
