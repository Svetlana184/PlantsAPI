using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class EquipmentService : IService<Equipment>
    {
        private readonly PostgresContext _context;

        public EquipmentService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipment>> GetAll()
        {
            return await _context.Equipment.ToListAsync();
        }

        public async Task<Equipment> GetById(int id)
        {
            return await _context.Equipment.FindAsync(id);
        }

        public async Task Create(Equipment entity)
        {
            await _context.Equipment.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Equipment entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Equipment.FindAsync(id);
            if (entity != null)
            {
                _context.Equipment.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
