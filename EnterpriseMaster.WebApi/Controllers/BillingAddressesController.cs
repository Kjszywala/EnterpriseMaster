using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BillingAddressesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BillingAddressesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/BillingAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillingAddresses>>> GetBillingAddresses()
        {
          if (_context.BillingAddresses == null)
          {
              return NotFound();
          }
            return await _context.BillingAddresses.ToListAsync();
        }

        // GET: api/BillingAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillingAddresses>> GetBillingAddresses(int id)
        {
          if (_context.BillingAddresses == null)
          {
              return NotFound();
          }
            var billingAddresses = await _context.BillingAddresses.FindAsync(id);

            if (billingAddresses == null)
            {
                return NotFound();
            }

            return billingAddresses;
        }

        // PUT: api/BillingAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillingAddresses(int id, BillingAddresses billingAddresses)
        {
            if (id != billingAddresses.Id)
            {
                return BadRequest();
            }

            _context.Entry(billingAddresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillingAddressesExists(id))
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

        // POST: api/BillingAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillingAddresses>> PostBillingAddresses(BillingAddresses billingAddresses)
        {
          if (_context.BillingAddresses == null)
          {
              return Problem("Entity set 'DatabaseContext.BillingAddresses'  is null.");
          }
            _context.BillingAddresses.Add(billingAddresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillingAddresses", new { id = billingAddresses.Id }, billingAddresses);
        }

        // DELETE: api/BillingAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillingAddresses(int id)
        {
            if (_context.BillingAddresses == null)
            {
                return NotFound();
            }
            var billingAddresses = await _context.BillingAddresses.FindAsync(id);
            if (billingAddresses == null)
            {
                return NotFound();
            }

            billingAddresses.ModificationDate = DateTime.Now;
            billingAddresses.IsActive = false;
            await PutBillingAddresses(id, billingAddresses);

            return NoContent();
        }

        private bool BillingAddressesExists(int id)
        {
            return (_context.BillingAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
