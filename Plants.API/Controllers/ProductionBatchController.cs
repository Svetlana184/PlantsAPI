using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductionBatchController : GenericController<ProductionBatch>
    {
        private readonly PostgresContext _context;

        public ProductionBatchController(IService<ProductionBatch> service, PostgresContext context)
            : base(service) => _context = context;

        // Получить активные партии
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var batches = await _context.ProductionBatches
                .Where(b => b.Status == "В работе" || b.Status == "Создана")
                .Include(b => b.IdProductNavigation)
                .Include(b => b.IdEquipmentNavigation)
                .ToListAsync();
            return Ok(batches);
        }

        // Получить партии с отклонениями
        [HttpGet("with-deviations")]
        public async Task<IActionResult> GetWithDeviations()
        {
            var batches = await _context.ProductionBatches
                .Where(b => b.Deviations.Any())
                .ToListAsync();
            return Ok(batches);
        }

        // Получить шаги партии
        [HttpGet("{id}/steps")]
        public async Task<IActionResult> GetSteps(int id)
        {
            var steps = await _context.BatchSteps
                .Where(s => s.IdProductionBatch == id)
                .ToListAsync();
            return Ok(steps);
        }

        // Запустить партию
        [HttpPost("{id}/start")]
        public async Task<IActionResult> StartBatch(int id)
        {
            var batch = await _context.ProductionBatches.FindAsync(id);
            if (batch == null) return NotFound();

            batch.Status = "В работе";
            batch.StartedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok(batch);
        }

        // Завершить партию
        [HttpPost("{id}/finish")]
        public async Task<IActionResult> FinishBatch(int id)
        {
            var batch = await _context.ProductionBatches.FindAsync(id);
            if (batch == null) return NotFound();

            batch.Status = "Завершена";
            batch.FinishedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok(batch);
        }
    }
}