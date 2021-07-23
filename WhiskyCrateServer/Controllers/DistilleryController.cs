﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiskyCrate.Data.Context;
using WhiskyCrate.Domain.Distillery;

namespace WhiskyCrate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistilleryController : ControllerBase
    {
        private readonly WhiskyCrateContext _context;

        public DistilleryController(WhiskyCrateContext context)
        {
            _context = context;
        }

        // GET: api/Distillery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distillery>>> GetDistilleries()
        {
            return await _context.Distilleries.ToListAsync();
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
        public async Task<IActionResult> PutDistillery(Guid id, Distillery distillery)
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

        private bool DistilleryExists(Guid id)
        {
            return _context.Distilleries.Any(e => e.Id == id);
        }
    }
}