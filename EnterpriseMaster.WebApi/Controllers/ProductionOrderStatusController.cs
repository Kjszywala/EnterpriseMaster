using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductionOrderStatusController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductionOrderStatusController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ProductionOrderStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionOrderStatus>>> GetProductionOrderStatus()
        {
          if (_context.ProductionOrderStatus == null)
          {
              return NotFound();
          }
            return await _context.ProductionOrderStatus.ToListAsync();
        }

        // GET: api/ProductionOrderStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionOrderStatus>> GetProductionOrderStatus(int id)
        {
          if (_context.ProductionOrderStatus == null)
          {
              return NotFound();
          }
            var productionOrderStatus = await _context.ProductionOrderStatus.FindAsync(id);

            if (productionOrderStatus == null)
            {
                return NotFound();
            }

            return productionOrderStatus;
        }

        // PUT: api/ProductionOrderStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductionOrderStatus(int id, ProductionOrderStatus productionOrderStatus)
        {
            if (id != productionOrderStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(productionOrderStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionOrderStatusExists(id))
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

        // POST: api/ProductionOrderStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductionOrderStatus>> PostProductionOrderStatus(ProductionOrderStatus productionOrderStatus)
        {
          if (_context.ProductionOrderStatus == null)
          {
              return Problem("Entity set 'DatabaseContext.ProductionOrderStatus'  is null.");
          }
            _context.ProductionOrderStatus.Add(productionOrderStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductionOrderStatus", new { id = productionOrderStatus.Id }, productionOrderStatus);
        }

        // DELETE: api/ProductionOrderStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionOrderStatus(int id)
        {
            if (_context.ProductionOrderStatus == null)
            {
                return NotFound();
            }
            var productionOrderStatus = await _context.ProductionOrderStatus.FindAsync(id);
            if (productionOrderStatus == null)
            {
                return NotFound();
            }

            productionOrderStatus.ModificationDate = DateTime.Now;
            productionOrderStatus.IsActive = false;
            await PutProductionOrderStatus(id, productionOrderStatus);

            return NoContent();
        }

        private bool ProductionOrderStatusExists(int id)
        {
            return (_context.ProductionOrderStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
