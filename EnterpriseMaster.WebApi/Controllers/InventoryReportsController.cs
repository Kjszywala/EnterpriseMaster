using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class InventoryReportsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public InventoryReportsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/InventoryReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryReports>>> GetInventoryReports()
        {
          if (_context.InventoryReports == null)
          {
              return NotFound();
          }
            return await _context.InventoryReports.ToListAsync();
        }

        // GET: api/InventoryReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryReports>> GetInventoryReports(int id)
        {
          if (_context.InventoryReports == null)
          {
              return NotFound();
          }
            var inventoryReports = await _context.InventoryReports.FindAsync(id);

            if (inventoryReports == null)
            {
                return NotFound();
            }

            return inventoryReports;
        }

        // PUT: api/InventoryReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryReports(int id, InventoryReports inventoryReports)
        {
            if (id != inventoryReports.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventoryReports).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryReportsExists(id))
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

        // POST: api/InventoryReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryReports>> PostInventoryReports(InventoryReports inventoryReports)
        {
          if (_context.InventoryReports == null)
          {
              return Problem("Entity set 'DatabaseContext.InventoryReports'  is null.");
          }
            _context.InventoryReports.Add(inventoryReports);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryReports", new { id = inventoryReports.Id }, inventoryReports);
        }

        // DELETE: api/InventoryReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryReports(int id)
        {
            if (_context.InventoryReports == null)
            {
                return NotFound();
            }
            var inventoryReports = await _context.InventoryReports.FindAsync(id);
            if (inventoryReports == null)
            {
                return NotFound();
            }

            inventoryReports.ModificationDate = DateTime.Now;
            inventoryReports.IsActive = false;
            await PutInventoryReports(id, inventoryReports);

            return NoContent();
        }

        private bool InventoryReportsExists(int id)
        {
            return (_context.InventoryReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
