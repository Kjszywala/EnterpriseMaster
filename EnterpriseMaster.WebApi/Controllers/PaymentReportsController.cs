using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PaymentReportsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PaymentReportsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PaymentReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentReports>>> GetPaymentReports()
        {
          if (_context.PaymentReports == null)
          {
              return NotFound();
          }
            return await _context.PaymentReports.ToListAsync();
        }

        // GET: api/PaymentReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentReports>> GetPaymentReports(int id)
        {
          if (_context.PaymentReports == null)
          {
              return NotFound();
          }
            var paymentReports = await _context.PaymentReports.FindAsync(id);

            if (paymentReports == null)
            {
                return NotFound();
            }

            return paymentReports;
        }

        // PUT: api/PaymentReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentReports(int id, PaymentReports paymentReports)
        {
            if (id != paymentReports.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentReports).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentReportsExists(id))
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

        // POST: api/PaymentReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentReports>> PostPaymentReports(PaymentReports paymentReports)
        {
          if (_context.PaymentReports == null)
          {
              return Problem("Entity set 'DatabaseContext.PaymentReports'  is null.");
          }
            _context.PaymentReports.Add(paymentReports);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentReports", new { id = paymentReports.Id }, paymentReports);
        }

        // DELETE: api/PaymentReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentReports(int id)
        {
            if (_context.PaymentReports == null)
            {
                return NotFound();
            }
            var paymentReports = await _context.PaymentReports.FindAsync(id);
            if (paymentReports == null)
            {
                return NotFound();
            }

            paymentReports.ModificationDate = DateTime.Now;
            paymentReports.IsActive = false;
            await PutPaymentReports(id, paymentReports);

            return NoContent();
        }

        private bool PaymentReportsExists(int id)
        {
            return (_context.PaymentReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
