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
    public class SubscriptionOrdersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SubscriptionOrdersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SubscriptionOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionOrders>>> GetSubscriptionOrders()
        {
          if (_context.SubscriptionOrders == null)
          {
              return NotFound();
          }
            return await _context.SubscriptionOrders.ToListAsync();
        }

        // GET: api/SubscriptionOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionOrders>> GetSubscriptionOrders(int id)
        {
          if (_context.SubscriptionOrders == null)
          {
              return NotFound();
          }
            var subscriptionOrders = await _context.SubscriptionOrders.FindAsync(id);

            if (subscriptionOrders == null)
            {
                return NotFound();
            }

            return subscriptionOrders;
        }

        // PUT: api/SubscriptionOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionOrders(int id, SubscriptionOrders subscriptionOrders)
        {
            if (id != subscriptionOrders.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscriptionOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionOrdersExists(id))
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

        // POST: api/SubscriptionOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubscriptionOrders>> PostSubscriptionOrders(SubscriptionOrders subscriptionOrders)
        {
          if (_context.SubscriptionOrders == null)
          {
              return Problem("Entity set 'DatabaseContext.SubscriptionOrders'  is null.");
          }
            _context.SubscriptionOrders.Add(subscriptionOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptionOrders", new { id = subscriptionOrders.Id }, subscriptionOrders);
        }

        // DELETE: api/SubscriptionOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionOrders(int id)
        {
            if (_context.SubscriptionOrders == null)
            {
                return NotFound();
            }
            var subscriptionOrders = await _context.SubscriptionOrders.FindAsync(id);
            if (subscriptionOrders == null)
            {
                return NotFound();
            }

            _context.SubscriptionOrders.Remove(subscriptionOrders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionOrdersExists(int id)
        {
            return (_context.SubscriptionOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
