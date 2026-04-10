using Microsoft.EntityFrameworkCore;

namespace Plants.API.Services
{
    public class GenericService<T> : IService<T> where T : class
    {
        private readonly PostgresContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericService(PostgresContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();
        public async Task<T> GetById(int id) => await _dbSet.FindAsync(id);
        public async Task Create(T entity) { await _dbSet.AddAsync(entity); await _context.SaveChangesAsync(); }
        public async Task Update(T entity) { _dbSet.Update(entity); await _context.SaveChangesAsync(); }
        public async Task Delete(int id) { var e = await GetById(id); if (e != null) _dbSet.Remove(e); await _context.SaveChangesAsync(); }
    }
}