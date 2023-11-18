using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReturnsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ReturnsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Returns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Returns>>> GetReturns()
        {
          if (_context.Returns == null)
          {
              return NotFound();
          }
            return await _context.Returns.ToListAsync();
        }

        // GET: api/Returns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Returns>> GetReturns(int id)
        {
          if (_context.Returns == null)
          {
              return NotFound();
          }
            var returns = await _context.Returns.FindAsync(id);

            if (returns == null)
            {
                return NotFound();
            }

            return returns;
        }

        // PUT: api/Returns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReturns(int id, Returns returns)
        {
            if (id != returns.Id)
            {
                return BadRequest();
            }

            _context.Entry(returns).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReturnsExists(id))
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

        // POST: api/Returns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Returns>> PostReturns(Returns returns)
        {
          if (_context.Returns == null)
          {
              return Problem("Entity set 'DatabaseContext.Returns'  is null.");
          }
            _context.Returns.Add(returns);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReturns", new { id = returns.Id }, returns);
        }

        // DELETE: api/Returns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturns(int id)
        {
            if (_context.Returns == null)
            {
                return NotFound();
            }
            var returns = await _context.Returns.FindAsync(id);
            if (returns == null)
            {
                return NotFound();
            }

            returns.ModificationDate = DateTime.Now;
            returns.IsActive = false;
            await PutReturns(id, returns);

            return NoContent();
        }

        private bool ReturnsExists(int id)
        {
            return (_context.Returns?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
