using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReturnsStatusesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ReturnsStatusesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ReturnsStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnsStatuses>>> GetReturnsStatuses()
        {
          if (_context.ReturnsStatuses == null)
          {
              return NotFound();
          }
            return await _context.ReturnsStatuses.ToListAsync();
        }

        // GET: api/ReturnsStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnsStatuses>> GetReturnsStatuses(int id)
        {
          if (_context.ReturnsStatuses == null)
          {
              return NotFound();
          }
            var returnsStatuses = await _context.ReturnsStatuses.FindAsync(id);

            if (returnsStatuses == null)
            {
                return NotFound();
            }

            return returnsStatuses;
        }

        // PUT: api/ReturnsStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReturnsStatuses(int id, ReturnsStatuses returnsStatuses)
        {
            if (id != returnsStatuses.Id)
            {
                return BadRequest();
            }

            _context.Entry(returnsStatuses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReturnsStatusesExists(id))
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

        // POST: api/ReturnsStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReturnsStatuses>> PostReturnsStatuses(ReturnsStatuses returnsStatuses)
        {
          if (_context.ReturnsStatuses == null)
          {
              return Problem("Entity set 'DatabaseContext.ReturnsStatuses'  is null.");
          }
            _context.ReturnsStatuses.Add(returnsStatuses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReturnsStatuses", new { id = returnsStatuses.Id }, returnsStatuses);
        }

        // DELETE: api/ReturnsStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturnsStatuses(int id)
        {
            if (_context.ReturnsStatuses == null)
            {
                return NotFound();
            }
            var returnsStatuses = await _context.ReturnsStatuses.FindAsync(id);
            if (returnsStatuses == null)
            {
                return NotFound();
            }

            returnsStatuses.ModificationDate = DateTime.Now;
            returnsStatuses.IsActive = false;
            await PutReturnsStatuses(id, returnsStatuses);

            return NoContent();
        }

        private bool ReturnsStatusesExists(int id)
        {
            return (_context.ReturnsStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
