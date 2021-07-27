using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WhiskyCrate.Application.Contracts.DistilleryService;
using WhiskyCrate.Data.Context;
using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistilleryController : ControllerBase
    {
        private readonly WhiskyCrateContext _context;
        private readonly IDistilleryService _distilleryService;

        public DistilleryController(WhiskyCrateContext context, IDistilleryService distilleryService)
        {
            _context = context;
            _distilleryService = distilleryService;
        }

        // GET: api/Distillery
        [HttpGet]
        public async Task<ActionResult> GetDistilleriesAsync()
        {
            var result = await _distilleryService.GetDistilleries();
            return Ok(result);
        }

        // GET: api/Distillery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Distillery>> GetDistillery(Guid id)
        {
            var distillery = await _context.Distilleries.FindAsync(id);

            if (distillery == null)
            {
                return NotFound();
            }

            return distillery;
        }

        // PUT: api/Distillery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistillery(int id, Distillery distillery)
        {
            if (id != distillery.Id)
            {
                return BadRequest();
            }

            _context.Entry(distillery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistilleryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Distillery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Distillery>> PostDistillery(Distillery distillery)
        {
            _context.Distilleries.Add(distillery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistillery", new { id = distillery.Id }, distillery);
        }

        // DELETE: api/Distillery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistillery(Guid id)
        {
            var distillery = await _context.Distilleries.FindAsync(id);
            if (distillery == null)
            {
                return NotFound();
            }

            _context.Distilleries.Remove(distillery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DistilleryExists(int id)
        {
            return _context.Distilleries.Any(e => e.Id == id);
        }
    }
}