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
    public class SubscriptionTypesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SubscriptionTypesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SubscriptionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionTypes>>> GetSubscriptionTypes()
        {
          if (_context.SubscriptionTypes == null)
          {
              return NotFound();
          }
            return await _context.SubscriptionTypes.ToListAsync();
        }

        // GET: api/SubscriptionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionTypes>> GetSubscriptionTypes(int id)
        {
          if (_context.SubscriptionTypes == null)
          {
              return NotFound();
          }
            var subscriptionTypes = await _context.SubscriptionTypes.FindAsync(id);

            if (subscriptionTypes == null)
            {
                return NotFound();
            }

            return subscriptionTypes;
        }

        // PUT: api/SubscriptionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionTypes(int id, SubscriptionTypes subscriptionTypes)
        {
            if (id != subscriptionTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscriptionTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionTypesExists(id))
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

        // POST: api/SubscriptionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubscriptionTypes>> PostSubscriptionTypes(SubscriptionTypes subscriptionTypes)
        {
          if (_context.SubscriptionTypes == null)
          {
              return Problem("Entity set 'DatabaseContext.SubscriptionTypes'  is null.");
          }
            _context.SubscriptionTypes.Add(subscriptionTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptionTypes", new { id = subscriptionTypes.Id }, subscriptionTypes);
        }

        // DELETE: api/SubscriptionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionTypes(int id)
        {
            if (_context.SubscriptionTypes == null)
            {
                return NotFound();
            }
            var subscriptionTypes = await _context.SubscriptionTypes.FindAsync(id);
            if (subscriptionTypes == null)
            {
                return NotFound();
            }

            _context.SubscriptionTypes.Remove(subscriptionTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionTypesExists(int id)
        {
            return (_context.SubscriptionTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
