using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductionOrdersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductionOrdersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ProductionOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionOrders>>> GetProductionOrders()
        {
          if (_context.ProductionOrders == null)
          {
              return NotFound();
          }
            return await _context.ProductionOrders.ToListAsync();
        }

        // GET: api/ProductionOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionOrders>> GetProductionOrders(int id)
        {
          if (_context.ProductionOrders == null)
          {
              return NotFound();
          }
            var productionOrders = await _context.ProductionOrders.FindAsync(id);

            if (productionOrders == null)
            {
                return NotFound();
            }

            return productionOrders;
        }

        // PUT: api/ProductionOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductionOrders(int id, ProductionOrders productionOrders)
        {
            if (id != productionOrders.Id)
            {
                return BadRequest();
            }

            _context.Entry(productionOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionOrdersExists(id))
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

        // POST: api/ProductionOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductionOrders>> PostProductionOrders(ProductionOrders productionOrders)
        {
          if (_context.ProductionOrders == null)
          {
              return Problem("Entity set 'DatabaseContext.ProductionOrders'  is null.");
          }
            _context.ProductionOrders.Add(productionOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductionOrders", new { id = productionOrders.Id }, productionOrders);
        }

        // DELETE: api/ProductionOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionOrders(int id)
        {
            if (_context.ProductionOrders == null)
            {
                return NotFound();
            }
            var productionOrders = await _context.ProductionOrders.FindAsync(id);
            if (productionOrders == null)
            {
                return NotFound();
            }

            productionOrders.ModificationDate = DateTime.Now;
            productionOrders.IsActive = false;
            await PutProductionOrders(id, productionOrders);

            return NoContent();
        }

        private bool ProductionOrdersExists(int id)
        {
            return (_context.ProductionOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
