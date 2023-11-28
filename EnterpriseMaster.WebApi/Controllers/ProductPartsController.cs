using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductPartsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductPartsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ProductParts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductParts>>> GetProductParts()
        {
          if (_context.ProductParts == null)
          {
              return NotFound();
          }
            return await _context.ProductParts.ToListAsync();
        }

        // GET: api/ProductParts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductParts>> GetProductParts(int id)
        {
          if (_context.ProductParts == null)
          {
              return NotFound();
          }
            var productParts = await _context.ProductParts.FindAsync(id);

            if (productParts == null)
            {
                return NotFound();
            }

            return productParts;
        }

        // PUT: api/ProductParts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductParts(int id, ProductParts productParts)
        {
            if (id != productParts.Id)
            {
                return BadRequest();
            }

            _context.Entry(productParts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPartsExists(id))
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

        // POST: api/ProductParts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductParts>> PostProductParts(ProductParts productParts)
        {
          if (_context.ProductParts == null)
          {
              return Problem("Entity set 'DatabaseContext.ProductParts'  is null.");
          }
            _context.ProductParts.Add(productParts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductParts", new { id = productParts.Id }, productParts);
        }

        // DELETE: api/ProductParts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductParts(int id)
        {
            if (_context.ProductParts == null)
            {
                return NotFound();
            }
            var productParts = await _context.ProductParts.FindAsync(id);
            if (productParts == null)
            {
                return NotFound();
            }

            productParts.ModificationDate = DateTime.Now;
            productParts.IsActive = false;
            await PutProductParts(id, productParts);

            return NoContent();
        }

        private bool ProductPartsExists(int id)
        {
            return (_context.ProductParts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
