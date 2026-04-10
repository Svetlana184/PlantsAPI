using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : GenericController<Recipe>
    {
        private readonly PostgresContext _context;

        public RecipeController(IService<Recipe> service, PostgresContext context)
            : base(service) => _context = context;

        // Получить компоненты рецепта
        [HttpGet("{id}/components")]
        public async Task<IActionResult> GetComponents(int id)
        {
            var components = await _context.RecipeComponents
                .Where(c => c.IdRecipe == id)
                .Include(c => c.IdRawMaterialNavigation)
                .OrderBy(c => c.LoadingOrder)
                .ToListAsync();
            return Ok(components);
        }

        // Получить утверждённые рецепты
        [HttpGet("approved")]
        public async Task<IActionResult> GetApproved()
        {
            var recipes = await _context.Recipes
                .Where(r => r.Status == "Утверждена")
                .ToListAsync();
            return Ok(recipes);
        }

        // Утвердить рецепт
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> Approve(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return NotFound();

            // Проверка суммы процентов
            var total = await _context.RecipeComponents
                .Where(c => c.IdRecipe == id)
                .SumAsync(c => c.Percentage);

            if (Math.Abs(total - 100m) > 0.01m)
                return BadRequest("Сумма компонентов не равна 100%");

            recipe.Status = "Утверждена";
            await _context.SaveChangesAsync();

            return Ok(recipe);
        }
    }
}