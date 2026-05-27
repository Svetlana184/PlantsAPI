using Microsoft.EntityFrameworkCore;
using Plants.API.Models;

namespace Plants.API.Services
{
    public class RecipeService : IService<Recipe>
    {
        private readonly PostgresContext _context;

        public RecipeService(PostgresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetById(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task Create(Recipe entity)
        {
            await _context.Recipes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Recipe entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Recipes.FindAsync(id);
            if (entity != null)
            {
                _context.Recipes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
