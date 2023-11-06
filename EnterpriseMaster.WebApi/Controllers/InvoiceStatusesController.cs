using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class InvoiceStatusesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public InvoiceStatusesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceStatuses>>> GetInvoiceStatuses()
        {
          if (_context.InvoiceStatuses == null)
          {
              return NotFound();
          }
            return await _context.InvoiceStatuses.ToListAsync();
        }

        // GET: api/InvoiceStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceStatuses>> GetInvoiceStatuses(int id)
        {
          if (_context.InvoiceStatuses == null)
          {
              return NotFound();
          }
            var invoiceStatuses = await _context.InvoiceStatuses.FindAsync(id);

            if (invoiceStatuses == null)
            {
                return NotFound();
            }

            return invoiceStatuses;
        }

        // PUT: api/InvoiceStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceStatuses(int id, InvoiceStatuses invoiceStatuses)
        {
            if (id != invoiceStatuses.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceStatuses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceStatusesExists(id))
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

        // POST: api/InvoiceStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceStatuses>> PostInvoiceStatuses(InvoiceStatuses invoiceStatuses)
        {
          if (_context.InvoiceStatuses == null)
          {
              return Problem("Entity set 'DatabaseContext.InvoiceStatuses'  is null.");
          }
            _context.InvoiceStatuses.Add(invoiceStatuses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceStatuses", new { id = invoiceStatuses.Id }, invoiceStatuses);
        }

        // DELETE: api/InvoiceStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceStatuses(int id)
        {
            if (_context.InvoiceStatuses == null)
            {
                return NotFound();
            }
            var invoiceStatuses = await _context.InvoiceStatuses.FindAsync(id);
            if (invoiceStatuses == null)
            {
                return NotFound();
            }

            _context.InvoiceStatuses.Remove(invoiceStatuses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceStatusesExists(int id)
        {
            return (_context.InvoiceStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
