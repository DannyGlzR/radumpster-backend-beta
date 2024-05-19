using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaDumpsterAPI.Data;
using RaDumpsterAPI.Models;

namespace RaDumpsterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DumpsterCategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DumpsterCategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DumpsterCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DumpsterCategory>>> GetDumpsterCategory()
        {
            return await _context.DumpsterCategory.ToListAsync();
        }

        // GET: api/DumpsterCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DumpsterCategory>> GetDumpsterCategory(int id)
        {
            var dumpsterCategory = await _context.DumpsterCategory.FindAsync(id);

            if (dumpsterCategory == null)
            {
                return NotFound();
            }

            return dumpsterCategory;
        }

        // PUT: api/DumpsterCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDumpsterCategory(int id, DumpsterCategory dumpsterCategory)
        {
            if (id != dumpsterCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(dumpsterCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DumpsterCategoryExists(id))
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

        // POST: api/DumpsterCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DumpsterCategory>> PostDumpsterCategory(DumpsterCategory dumpsterCategory)
        {
            _context.DumpsterCategory.Add(dumpsterCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDumpsterCategory", new { id = dumpsterCategory.Id }, dumpsterCategory);
        }

        // DELETE: api/DumpsterCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDumpsterCategory(int id)
        {
            var dumpsterCategory = await _context.DumpsterCategory.FindAsync(id);
            if (dumpsterCategory == null)
            {
                return NotFound();
            }

            _context.DumpsterCategory.Remove(dumpsterCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DumpsterCategoryExists(int id)
        {
            return _context.DumpsterCategory.Any(e => e.Id == id);
        }
    }
}
