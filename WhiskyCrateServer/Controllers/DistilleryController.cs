using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhiskyCrate.API.Managers;
using WhiskyCrate.Application.Contracts.DistilleryService;

namespace WhiskyCrate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistilleryController : ControllerBase
    {
        private readonly IDistilleryService _distilleryService;
        private readonly ISearchDistilleriesManager searchDistilleriesManager;
        private readonly IGetDistilleryManager getDistilleryManager;
        private readonly IDistilleryPutManager distilleryPutManager;
        private readonly IDistilleryAddManager distilleryAddManager;

        public DistilleryController(IDistilleryService distilleryService, ISearchDistilleriesManager searchDistilleriesManager, IGetDistilleryManager getDistilleryManager, IDistilleryPutManager distilleryPutManager, IDistilleryAddManager distilleryAddManager)
        {
            _distilleryService = distilleryService;
            this.searchDistilleriesManager = searchDistilleriesManager;
            this.getDistilleryManager = getDistilleryManager;
            this.distilleryPutManager = distilleryPutManager;
            this.distilleryAddManager = distilleryAddManager;
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

            if (!await _distilleryService.DistilleryExists(id))
            {
                return NotFound();
            }

            await distilleryPutManager.UpdateDistillery(distillery);

            return Ok();
        }

        // POST: api/Distillery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDistillery(DistilleryAddRequest distillery)
        {
            await distilleryAddManager.AddDistillery(distillery);
            return Ok();
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
    }
}