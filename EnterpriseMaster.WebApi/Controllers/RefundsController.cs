using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RefundsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RefundsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Refunds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Refunds>>> GetRefunds()
        {
          if (_context.Refunds == null)
          {
              return NotFound();
          }
            return await _context.Refunds.ToListAsync();
        }

        // GET: api/Refunds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Refunds>> GetRefunds(int id)
        {
          if (_context.Refunds == null)
          {
              return NotFound();
          }
            var refunds = await _context.Refunds.FindAsync(id);

            if (refunds == null)
            {
                return NotFound();
            }

            return refunds;
        }

        // PUT: api/Refunds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefunds(int id, Refunds refunds)
        {
            if (id != refunds.Id)
            {
                return BadRequest();
            }

            _context.Entry(refunds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefundsExists(id))
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

        // POST: api/Refunds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Refunds>> PostRefunds(Refunds refunds)
        {
          if (_context.Refunds == null)
          {
              return Problem("Entity set 'DatabaseContext.Refunds'  is null.");
          }
            _context.Refunds.Add(refunds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRefunds", new { id = refunds.Id }, refunds);
        }

        // DELETE: api/Refunds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefunds(int id)
        {
            if (_context.Refunds == null)
            {
                return NotFound();
            }
            var refunds = await _context.Refunds.FindAsync(id);
            if (refunds == null)
            {
                return NotFound();
            }

            refunds.ModificationDate = DateTime.Now;
            refunds.IsActive = false;
            await PutRefunds(id, refunds);

            return NoContent();
        }

        private bool RefundsExists(int id)
        {
            return (_context.Refunds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
