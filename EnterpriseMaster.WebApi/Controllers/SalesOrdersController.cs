using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SalesOrdersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SalesOrdersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SalesOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrders>>> GetSalesOrders()
        {
          if (_context.SalesOrders == null)
          {
              return NotFound();
          }
            return await _context.SalesOrders.ToListAsync();
        }

        // GET: api/SalesOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrders>> GetSalesOrders(int id)
        {
          if (_context.SalesOrders == null)
          {
              return NotFound();
          }
            var salesOrders = await _context.SalesOrders.FindAsync(id);

            if (salesOrders == null)
            {
                return NotFound();
            }

            return salesOrders;
        }

        // PUT: api/SalesOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesOrders(int id, SalesOrders salesOrders)
        {
            if (id != salesOrders.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrdersExists(id))
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

        // POST: api/SalesOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesOrders>> PostSalesOrders(SalesOrders salesOrders)
        {
          if (_context.SalesOrders == null)
          {
              return Problem("Entity set 'DatabaseContext.SalesOrders'  is null.");
          }
            _context.SalesOrders.Add(salesOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesOrders", new { id = salesOrders.Id }, salesOrders);
        }

        // DELETE: api/SalesOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesOrders(int id)
        {
            if (_context.SalesOrders == null)
            {
                return NotFound();
            }
            var salesOrders = await _context.SalesOrders.FindAsync(id);
            if (salesOrders == null)
            {
                return NotFound();
            }

            salesOrders.ModificationDate = DateTime.Now;
            salesOrders.IsActive = false;
            await PutSalesOrders(id, salesOrders);

            return NoContent();
        }

        private bool SalesOrdersExists(int id)
        {
            return (_context.SalesOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
