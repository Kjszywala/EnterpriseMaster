using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PaymentStatusController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PaymentStatusController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PaymentStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentStatus>>> GetPaymentStatus()
        {
          if (_context.PaymentStatus == null)
          {
              return NotFound();
          }
            return await _context.PaymentStatus.ToListAsync();
        }

        // GET: api/PaymentStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentStatus>> GetPaymentStatus(int id)
        {
          if (_context.PaymentStatus == null)
          {
              return NotFound();
          }
            var paymentStatus = await _context.PaymentStatus.FindAsync(id);

            if (paymentStatus == null)
            {
                return NotFound();
            }

            return paymentStatus;
        }

        // PUT: api/PaymentStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentStatus(int id, PaymentStatus paymentStatus)
        {
            if (id != paymentStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentStatusExists(id))
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

        // POST: api/PaymentStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentStatus>> PostPaymentStatus(PaymentStatus paymentStatus)
        {
          if (_context.PaymentStatus == null)
          {
              return Problem("Entity set 'DatabaseContext.PaymentStatus'  is null.");
          }
            _context.PaymentStatus.Add(paymentStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentStatus", new { id = paymentStatus.Id }, paymentStatus);
        }

        // DELETE: api/PaymentStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentStatus(int id)
        {
            if (_context.PaymentStatus == null)
            {
                return NotFound();
            }
            var paymentStatus = await _context.PaymentStatus.FindAsync(id);
            if (paymentStatus == null)
            {
                return NotFound();
            }

            paymentStatus.ModificationDate = DateTime.Now;
            paymentStatus.IsActive = false;
            await PutPaymentStatus(id, paymentStatus);

            return NoContent();
        }

        private bool PaymentStatusExists(int id)
        {
            return (_context.PaymentStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
