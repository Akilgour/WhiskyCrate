using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WhiskyCrate.API.Managers;
using WhiskyCrate.Application.Contracts.Distilleries;
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
        private readonly ISearchDistilleriesManager searchDistilleriesManager;
        private readonly IGetDistilleryManager getDistilleryManager;
        private readonly IDistilleryPutManager distilleryPutManager;

        public DistilleryController(WhiskyCrateContext context, IDistilleryService distilleryService, ISearchDistilleriesManager searchDistilleriesManager, IGetDistilleryManager getDistilleryManager , IDistilleryPutManager distilleryPutManager
            )
        {
            _context = context;
            _distilleryService = distilleryService;
            this.searchDistilleriesManager = searchDistilleriesManager;
            this.getDistilleryManager = getDistilleryManager;
            this.distilleryPutManager = distilleryPutManager;
        }

        // GET: api/Distillery
        [HttpGet]
        public async Task<IActionResult> GetDistilleries()
        {
            var result = await searchDistilleriesManager.GetDistilleries();
            return Ok(result);
        }

        // GET: api/Distillery/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistillery(int id)
        {
            var result = await getDistilleryManager.GetDistillery(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // PUT: api/Distillery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistillery(int id, DistilleryPutRequest distillery)
        {
            if (id != distillery.Id)
            {
                return BadRequest();
            }

            if (! await _distilleryService.DistilleryExists(id))
            {
                return NotFound();
            }

             await distilleryPutManager.UpdateDistillery(distillery);

            return Ok( );
        }

        // POST: api/Distillery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDistillery(DistilleryPostRequest distillery)
        {
            var result = await _distilleryService.AddDistillery(distillery);
            return CreatedAtAction("GetDistillery", new { id = result.Id }, distillery);
        }

        // DELETE: api/Distillery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistillery(int id)
        {
            var deleted = await _distilleryService.DeleteDistillery(id);
            if (deleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private bool DistilleryExists(int id)
        {
            return _context.Distilleries.Any(e => e.Id == id);
        }
    }
}