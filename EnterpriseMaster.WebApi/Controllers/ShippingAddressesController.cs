using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ShippingAddressesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ShippingAddressesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ShippingAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingAddresses>>> GetShippingAddresses()
        {
          if (_context.ShippingAddresses == null)
          {
              return NotFound();
          }
            return await _context.ShippingAddresses.ToListAsync();
        }

        // GET: api/ShippingAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingAddresses>> GetShippingAddresses(int id)
        {
          if (_context.ShippingAddresses == null)
          {
              return NotFound();
          }
            var shippingAddresses = await _context.ShippingAddresses.FindAsync(id);

            if (shippingAddresses == null)
            {
                return NotFound();
            }

            return shippingAddresses;
        }

        // PUT: api/ShippingAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingAddresses(int id, ShippingAddresses shippingAddresses)
        {
            if (id != shippingAddresses.Id)
            {
                return BadRequest();
            }

            _context.Entry(shippingAddresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingAddressesExists(id))
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

        // POST: api/ShippingAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShippingAddresses>> PostShippingAddresses(ShippingAddresses shippingAddresses)
        {
          if (_context.ShippingAddresses == null)
          {
              return Problem("Entity set 'DatabaseContext.ShippingAddresses'  is null.");
          }
            _context.ShippingAddresses.Add(shippingAddresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShippingAddresses", new { id = shippingAddresses.Id }, shippingAddresses);
        }

        // DELETE: api/ShippingAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingAddresses(int id)
        {
            if (_context.ShippingAddresses == null)
            {
                return NotFound();
            }
            var shippingAddresses = await _context.ShippingAddresses.FindAsync(id);
            if (shippingAddresses == null)
            {
                return NotFound();
            }

            shippingAddresses.ModificationDate = DateTime.UtcNow;
            shippingAddresses.IsActive = false;
            await PutShippingAddresses(id, shippingAddresses);

            return NoContent();
        }

        private bool ShippingAddressesExists(int id)
        {
            return (_context.ShippingAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
