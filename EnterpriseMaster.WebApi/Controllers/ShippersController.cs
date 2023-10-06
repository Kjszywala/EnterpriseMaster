using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ShippersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Shippers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shippers>>> GetShippers()
        {
          if (_context.Shippers == null)
          {
              return NotFound();
          }
            return await _context.Shippers.ToListAsync();
        }

        // GET: api/Shippers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shippers>> GetShippers(int id)
        {
          if (_context.Shippers == null)
          {
              return NotFound();
          }
            var shippers = await _context.Shippers.FindAsync(id);

            if (shippers == null)
            {
                return NotFound();
            }

            return shippers;
        }

        // PUT: api/Shippers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippers(int id, Shippers shippers)
        {
            if (id != shippers.Id)
            {
                return BadRequest();
            }

            _context.Entry(shippers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippersExists(id))
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

        // POST: api/Shippers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shippers>> PostShippers(Shippers shippers)
        {
          if (_context.Shippers == null)
          {
              return Problem("Entity set 'DatabaseContext.Shippers'  is null.");
          }
            _context.Shippers.Add(shippers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShippers", new { id = shippers.Id }, shippers);
        }

        // DELETE: api/Shippers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippers(int id)
        {
            if (_context.Shippers == null)
            {
                return NotFound();
            }
            var shippers = await _context.Shippers.FindAsync(id);
            if (shippers == null)
            {
                return NotFound();
            }

            shippers.ModificationDate = DateTime.Now;
            shippers.IsActive = false;
            await PutShippers(id, shippers);

            return NoContent();
        }

        private bool ShippersExists(int id)
        {
            return (_context.Shippers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
