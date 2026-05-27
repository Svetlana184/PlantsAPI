using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class LabTestService : IService<LabTest>
    {
        private readonly PostgresContext _context;

        public LabTestService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LabTest>> GetAll()
        {
            return await _context.LabTests.ToListAsync();
        }

        public async Task<LabTest> GetById(int id)
        {
            return await _context.LabTests.FindAsync(id);
        }

        public async Task Create(LabTest entity)
        {
            await _context.LabTests.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(LabTest entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.LabTests.FindAsync(id);
            if (entity != null)
            {
                _context.LabTests.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
