using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrderStatusesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrderStatusesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/OrderStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatuses>>> GetOrderStatuses()
        {
          if (_context.OrderStatuses == null)
          {
              return NotFound();
          }
            return await _context.OrderStatuses.ToListAsync();
        }

        // GET: api/OrderStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatuses>> GetOrderStatuses(int id)
        {
          if (_context.OrderStatuses == null)
          {
              return NotFound();
          }
            var orderStatuses = await _context.OrderStatuses.FindAsync(id);

            if (orderStatuses == null)
            {
                return NotFound();
            }

            return orderStatuses;
        }

        // PUT: api/OrderStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderStatuses(int id, OrderStatuses orderStatuses)
        {
            if (id != orderStatuses.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderStatuses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderStatusesExists(id))
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

        // POST: api/OrderStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderStatuses>> PostOrderStatuses(OrderStatuses orderStatuses)
        {
          if (_context.OrderStatuses == null)
          {
              return Problem("Entity set 'DatabaseContext.OrderStatuses'  is null.");
          }
            _context.OrderStatuses.Add(orderStatuses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderStatuses", new { id = orderStatuses.Id }, orderStatuses);
        }

        // DELETE: api/OrderStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderStatuses(int id)
        {
            if (_context.OrderStatuses == null)
            {
                return NotFound();
            }
            var orderStatuses = await _context.OrderStatuses.FindAsync(id);
            if (orderStatuses == null)
            {
                return NotFound();
            }

            orderStatuses.ModificationDate = DateTime.Now;
            orderStatuses.IsActive = false;
            await PutOrderStatuses(id, orderStatuses);

            return NoContent();
        }

        private bool OrderStatusesExists(int id)
        {
            return (_context.OrderStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
