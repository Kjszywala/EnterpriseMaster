using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerAddressesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CustomerAddressesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CustomerAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerAddresses>>> GetCustomerAddresses()
        {
          if (_context.CustomerAddresses == null)
          {
              return NotFound();
          }
            return await _context.CustomerAddresses.ToListAsync();
        }

        // GET: api/CustomerAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerAddresses>> GetCustomerAddresses(int id)
        {
          if (_context.CustomerAddresses == null)
          {
              return NotFound();
          }
            var customerAddresses = await _context.CustomerAddresses.FindAsync(id);

            if (customerAddresses == null)
            {
                return NotFound();
            }

            return customerAddresses;
        }

        // PUT: api/CustomerAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerAddresses(int id, CustomerAddresses customerAddresses)
        {
            if (id != customerAddresses.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerAddresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerAddressesExists(id))
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

        // POST: api/CustomerAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerAddresses>> PostCustomerAddresses(CustomerAddresses customerAddresses)
        {
          if (_context.CustomerAddresses == null)
          {
              return Problem("Entity set 'DatabaseContext.CustomerAddresses'  is null.");
          }
            _context.CustomerAddresses.Add(customerAddresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerAddresses", new { id = customerAddresses.Id }, customerAddresses);
        }

        // DELETE: api/CustomerAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAddresses(int id)
        {
            if (_context.CustomerAddresses == null)
            {
                return NotFound();
            }
            var customerAddresses = await _context.CustomerAddresses.FindAsync(id);
            if (customerAddresses == null)
            {
                return NotFound();
            }

            customerAddresses.ModificationDate = DateTime.Now;
            customerAddresses.IsActive = false;
            await PutCustomerAddresses(id, customerAddresses);

            return NoContent();
        }

        private bool CustomerAddressesExists(int id)
        {
            return (_context.CustomerAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
