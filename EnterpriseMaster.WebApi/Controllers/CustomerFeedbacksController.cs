using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerFeedbacksController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CustomerFeedbacksController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CustomerFeedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerFeedbacks>>> GetCustomerFeedbacks()
        {
          if (_context.CustomerFeedbacks == null)
          {
              return NotFound();
          }
            return await _context.CustomerFeedbacks.ToListAsync();
        }

        // GET: api/CustomerFeedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerFeedbacks>> GetCustomerFeedbacks(int id)
        {
          if (_context.CustomerFeedbacks == null)
          {
              return NotFound();
          }
            var customerFeedbacks = await _context.CustomerFeedbacks.FindAsync(id);

            if (customerFeedbacks == null)
            {
                return NotFound();
            }

            return customerFeedbacks;
        }

        // PUT: api/CustomerFeedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerFeedbacks(int id, CustomerFeedbacks customerFeedbacks)
        {
            if (id != customerFeedbacks.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerFeedbacks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerFeedbacksExists(id))
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

        // POST: api/CustomerFeedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerFeedbacks>> PostCustomerFeedbacks(CustomerFeedbacks customerFeedbacks)
        {
          if (_context.CustomerFeedbacks == null)
          {
              return Problem("Entity set 'DatabaseContext.CustomerFeedbacks'  is null.");
          }
            _context.CustomerFeedbacks.Add(customerFeedbacks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerFeedbacks", new { id = customerFeedbacks.Id }, customerFeedbacks);
        }

        // DELETE: api/CustomerFeedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerFeedbacks(int id)
        {
            if (_context.CustomerFeedbacks == null)
            {
                return NotFound();
            }
            var customerFeedbacks = await _context.CustomerFeedbacks.FindAsync(id);
            if (customerFeedbacks == null)
            {
                return NotFound();
            }

            customerFeedbacks.ModificationDate = DateTime.Now;
            customerFeedbacks.IsActive = false;
            await PutCustomerFeedbacks(id, customerFeedbacks);

            return NoContent();
        }

        private bool CustomerFeedbacksExists(int id)
        {
            return (_context.CustomerFeedbacks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
