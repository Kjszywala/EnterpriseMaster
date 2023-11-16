using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PurchaseOrdersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrders>>> GetPurchaseOrders()
        {
          if (_context.PurchaseOrders == null)
          {
              return NotFound();
          }
            return await _context.PurchaseOrders.ToListAsync();
        }

        // GET: api/PurchaseOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrders>> GetPurchaseOrders(int id)
        {
          if (_context.PurchaseOrders == null)
          {
              return NotFound();
          }
            var purchaseOrders = await _context.PurchaseOrders.FindAsync(id);

            if (purchaseOrders == null)
            {
                return NotFound();
            }

            return purchaseOrders;
        }

        // PUT: api/PurchaseOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseOrders(int id, PurchaseOrders purchaseOrders)
        {
            if (id != purchaseOrders.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrdersExists(id))
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

        // POST: api/PurchaseOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseOrders>> PostPurchaseOrders(PurchaseOrders purchaseOrders)
        {
          if (_context.PurchaseOrders == null)
          {
              return Problem("Entity set 'DatabaseContext.PurchaseOrders'  is null.");
          }
            _context.PurchaseOrders.Add(purchaseOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseOrders", new { id = purchaseOrders.Id }, purchaseOrders);
        }

        // DELETE: api/PurchaseOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseOrders(int id)
        {
            if (_context.PurchaseOrders == null)
            {
                return NotFound();
            }
            var purchaseOrders = await _context.PurchaseOrders.FindAsync(id);
            if (purchaseOrders == null)
            {
                return NotFound();
            }

            purchaseOrders.ModificationDate = DateTime.Now;
            purchaseOrders.IsActive = false;
            await PutPurchaseOrders(id, purchaseOrders);

            return NoContent();
        }

        private bool PurchaseOrdersExists(int id)
        {
            return (_context.PurchaseOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
