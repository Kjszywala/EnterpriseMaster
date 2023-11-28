using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PartsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Parts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parts>>> GetParts()
        {
          if (_context.Parts == null)
          {
              return NotFound();
          }
            return await _context.Parts.ToListAsync();
        }

        // GET: api/Parts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parts>> GetParts(int id)
        {
          if (_context.Parts == null)
          {
              return NotFound();
          }
            var parts = await _context.Parts.FindAsync(id);

            if (parts == null)
            {
                return NotFound();
            }

            return parts;
        }

        // PUT: api/Parts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParts(int id, Parts parts)
        {
            if (id != parts.Id)
            {
                return BadRequest();
            }

            _context.Entry(parts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartsExists(id))
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

        // POST: api/Parts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parts>> PostParts(Parts parts)
        {
          if (_context.Parts == null)
          {
              return Problem("Entity set 'DatabaseContext.Parts'  is null.");
          }
            _context.Parts.Add(parts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParts", new { id = parts.Id }, parts);
        }

        // DELETE: api/Parts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParts(int id)
        {
            if (_context.Parts == null)
            {
                return NotFound();
            }
            var parts = await _context.Parts.FindAsync(id);
            if (parts == null)
            {
                return NotFound();
            }

            parts.ModificationDate = DateTime.Now;
            parts.IsActive = false;
            await PutParts(id, parts);

            return NoContent();
        }

        private bool PartsExists(int id)
        {
            return (_context.Parts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
