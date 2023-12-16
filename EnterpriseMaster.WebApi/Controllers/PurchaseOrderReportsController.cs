using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PurchaseOrderReportsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PurchaseOrderReportsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrderReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderReports>>> GetPurchaseOrderReports()
        {
          if (_context.PurchaseOrderReports == null)
          {
              return NotFound();
          }
            return await _context.PurchaseOrderReports.ToListAsync();
        }

        // GET: api/PurchaseOrderReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderReports>> GetPurchaseOrderReports(int id)
        {
          if (_context.PurchaseOrderReports == null)
          {
              return NotFound();
          }
            var purchaseOrderReports = await _context.PurchaseOrderReports.FindAsync(id);

            if (purchaseOrderReports == null)
            {
                return NotFound();
            }

            return purchaseOrderReports;
        }

        // PUT: api/PurchaseOrderReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseOrderReports(int id, PurchaseOrderReports purchaseOrderReports)
        {
            if (id != purchaseOrderReports.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrderReports).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderReportsExists(id))
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

        // POST: api/PurchaseOrderReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseOrderReports>> PostPurchaseOrderReports(PurchaseOrderReports purchaseOrderReports)
        {
          if (_context.PurchaseOrderReports == null)
          {
              return Problem("Entity set 'DatabaseContext.PurchaseOrderReports'  is null.");
          }
            _context.PurchaseOrderReports.Add(purchaseOrderReports);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseOrderReports", new { id = purchaseOrderReports.Id }, purchaseOrderReports);
        }

        // DELETE: api/PurchaseOrderReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseOrderReports(int id)
        {
            if (_context.PurchaseOrderReports == null)
            {
                return NotFound();
            }
            var purchaseOrderReports = await _context.PurchaseOrderReports.FindAsync(id);
            if (purchaseOrderReports == null)
            {
                return NotFound();
            }

            purchaseOrderReports.ModificationDate = DateTime.Now;
            purchaseOrderReports.IsActive = false;
            await PutPurchaseOrderReports(id, purchaseOrderReports);

            return NoContent();
        }

        private bool PurchaseOrderReportsExists(int id)
        {
            return (_context.PurchaseOrderReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
