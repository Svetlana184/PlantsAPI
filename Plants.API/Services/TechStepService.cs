using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class TechStepService : IService<TechStep>
    {
        private readonly PostgresContext _context;

        public TechStepService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechStep>> GetAll()
        {
            return await _context.TechSteps.ToListAsync();
        }

        public async Task<TechStep> GetById(int id)
        {
            return await _context.TechSteps.FindAsync(id);
        }

        public async Task Create(TechStep entity)
        {
            await _context.TechSteps.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TechStep entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.TechSteps.FindAsync(id);
            if (entity != null)
            {
                _context.TechSteps.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
