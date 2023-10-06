using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PaymentMethodsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PaymentMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethods>>> GetPaymentMethods()
        {
          if (_context.PaymentMethods == null)
          {
              return NotFound();
          }
            return await _context.PaymentMethods.ToListAsync();
        }

        // GET: api/PaymentMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethods>> GetPaymentMethods(int id)
        {
          if (_context.PaymentMethods == null)
          {
              return NotFound();
          }
            var paymentMethods = await _context.PaymentMethods.FindAsync(id);

            if (paymentMethods == null)
            {
                return NotFound();
            }

            return paymentMethods;
        }

        // PUT: api/PaymentMethods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethods(int id, PaymentMethods paymentMethods)
        {
            if (id != paymentMethods.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentMethods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodsExists(id))
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

        // POST: api/PaymentMethods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentMethods>> PostPaymentMethods(PaymentMethods paymentMethods)
        {
          if (_context.PaymentMethods == null)
          {
              return Problem("Entity set 'DatabaseContext.PaymentMethods'  is null.");
          }
            _context.PaymentMethods.Add(paymentMethods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentMethods", new { id = paymentMethods.Id }, paymentMethods);
        }

        // DELETE: api/PaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethods(int id)
        {
            if (_context.PaymentMethods == null)
            {
                return NotFound();
            }
            var paymentMethods = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethods == null)
            {
                return NotFound();
            }

            _context.PaymentMethods.Remove(paymentMethods);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentMethodsExists(int id)
        {
            return (_context.PaymentMethods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
