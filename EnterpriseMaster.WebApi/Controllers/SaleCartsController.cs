using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SaleCartsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SaleCartsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SaleCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleCart>>> GetSaleCart()
        {
          if (_context.SaleCart == null)
          {
              return NotFound();
          }
            return await _context.SaleCart.ToListAsync();
        }

        // GET: api/SaleCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleCart>> GetSaleCart(int id)
        {
          if (_context.SaleCart == null)
          {
              return NotFound();
          }
            var saleCart = await _context.SaleCart.FindAsync(id);

            if (saleCart == null)
            {
                return NotFound();
            }

            return saleCart;
        }

        // PUT: api/SaleCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleCart(int id, SaleCart saleCart)
        {
            if (id != saleCart.Id)
            {
                return BadRequest();
            }

            _context.Entry(saleCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleCartExists(id))
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

        // POST: api/SaleCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaleCart>> PostSaleCart(SaleCart saleCart)
        {
          if (_context.SaleCart == null)
          {
              return Problem("Entity set 'DatabaseContext.SaleCart'  is null.");
          }
            _context.SaleCart.Add(saleCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaleCart", new { id = saleCart.Id }, saleCart);
        }

        // DELETE: api/SaleCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleCart(int id)
        {
            if (_context.SaleCart == null)
            {
                return NotFound();
            }
            var saleCart = await _context.SaleCart.FindAsync(id);
            if (saleCart == null)
            {
                return NotFound();
            }

            _context.SaleCart.Remove(saleCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleCartExists(int id)
        {
            return (_context.SaleCart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
