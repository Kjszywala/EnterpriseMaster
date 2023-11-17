using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ShippersAddressesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ShippersAddressesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ShippersAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippersAddresses>>> GetShippersAddresses()
        {
          if (_context.ShippersAddresses == null)
          {
              return NotFound();
          }
            return await _context.ShippersAddresses.ToListAsync();
        }

        // GET: api/ShippersAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippersAddresses>> GetShippersAddresses(int id)
        {
          if (_context.ShippersAddresses == null)
          {
              return NotFound();
          }
            var shippersAddresses = await _context.ShippersAddresses.FindAsync(id);

            if (shippersAddresses == null)
            {
                return NotFound();
            }

            return shippersAddresses;
        }

        // PUT: api/ShippersAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippersAddresses(int id, ShippersAddresses shippersAddresses)
        {
            if (id != shippersAddresses.Id)
            {
                return BadRequest();
            }

            _context.Entry(shippersAddresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippersAddressesExists(id))
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

        // POST: api/ShippersAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShippersAddresses>> PostShippersAddresses(ShippersAddresses shippersAddresses)
        {
          if (_context.ShippersAddresses == null)
          {
              return Problem("Entity set 'DatabaseContext.ShippersAddresses'  is null.");
          }
            _context.ShippersAddresses.Add(shippersAddresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShippersAddresses", new { id = shippersAddresses.Id }, shippersAddresses);
        }

        // DELETE: api/ShippersAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippersAddresses(int id)
        {
            if (_context.ShippersAddresses == null)
            {
                return NotFound();
            }
            var shippersAddresses = await _context.ShippersAddresses.FindAsync(id);
            if (shippersAddresses == null)
            {
                return NotFound();
            }

            shippersAddresses.ModificationDate = DateTime.Now;
            shippersAddresses.IsActive = false;
            await PutShippersAddresses(id, shippersAddresses);

            return NoContent();
        }

        private bool ShippersAddressesExists(int id)
        {
            return (_context.ShippersAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
