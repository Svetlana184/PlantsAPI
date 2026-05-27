using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class DepartmentService : IService<Department>
    {
        private readonly PostgresContext _context;

        public DepartmentService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task Create(Department entity)
        {
            await _context.Departments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Department entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Departments.FindAsync(id);
            if (entity != null)
            {
                _context.Departments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
