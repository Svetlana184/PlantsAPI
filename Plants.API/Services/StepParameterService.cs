using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class StepParameterService : IService<StepParameter>
    {
        private readonly PostgresContext _context;

        public StepParameterService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StepParameter>> GetAll()
        {
            return await _context.StepParameters.ToListAsync();
        }

        public async Task<StepParameter> GetById(int id)
        {
            return await _context.StepParameters.FindAsync(id);
        }

        public async Task Create(StepParameter entity)
        {
            await _context.StepParameters.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(StepParameter entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.StepParameters.FindAsync(id);
            if (entity != null)
            {
                _context.StepParameters.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
