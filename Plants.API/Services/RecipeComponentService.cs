using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class RecipeComponentService : IService<RecipeComponent>
    {
        private readonly PostgresContext _context;

        public RecipeComponentService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipeComponent>> GetAll()
        {
            return await _context.RecipeComponents.ToListAsync();
        }

        public async Task<RecipeComponent> GetById(int id)
        {
            return await _context.RecipeComponents.FindAsync(id);
        }

        public async Task Create(RecipeComponent entity)
        {
            await _context.RecipeComponents.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(RecipeComponent entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.RecipeComponents.FindAsync(id);
            if (entity != null)
            {
                _context.RecipeComponents.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
