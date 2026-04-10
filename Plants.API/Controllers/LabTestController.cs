using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Route("api/[controller]")]
    public class LabTestController : GenericController<LabTest>
    {
        private readonly PostgresContext _context;

        public LabTestController(IService<LabTest> service, PostgresContext context)
            : base(service) => _context = context;

        // Получить испытания по партии
        [HttpGet("by-batch/{batchId}")]
        public async Task<IActionResult> GetByBatch(int batchId)
        {
            var tests = await _context.LabTests
                .Where(t => t.IdProductionBatch == batchId)
                .Include(t => t.LabResults)
                .ToListAsync();
            return Ok(tests);
        }

        // Получить испытания по сырью
        [HttpGet("by-raw-batch/{rawBatchId}")]
        public async Task<IActionResult> GetByRawBatch(int rawBatchId)
        {
            var tests = await _context.LabTests
                .Where(t => t.IdRawMaterialBatch == rawBatchId)
                .Include(t => t.LabResults)
                .ToListAsync();
            return Ok(tests);
        }

        // Завершить испытание
        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(int id, [FromBody] LabTest result)
        {
            var test = await _context.LabTests.FindAsync(id);
            if (test == null) return NotFound();

            test.Status = "Завершен";
            test.FinishedAt = DateTime.UtcNow;
            test.Conclusion = result.Conclusion;
            test.Comment = result.Comment;

            await _context.SaveChangesAsync();

            return Ok(test);
        }
    }
}