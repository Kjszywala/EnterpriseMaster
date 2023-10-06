using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QuantityTypesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public QuantityTypesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/QuantityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuantityTypes>>> GetQuantityTypes()
        {
          if (_context.QuantityTypes == null)
          {
              return NotFound();
          }
            return await _context.QuantityTypes.ToListAsync();
        }

        // GET: api/QuantityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuantityTypes>> GetQuantityTypes(int id)
        {
          if (_context.QuantityTypes == null)
          {
              return NotFound();
          }
            var quantityTypes = await _context.QuantityTypes.FindAsync(id);

            if (quantityTypes == null)
            {
                return NotFound();
            }

            return quantityTypes;
        }

        // PUT: api/QuantityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuantityTypes(int id, QuantityTypes quantityTypes)
        {
            if (id != quantityTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(quantityTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuantityTypesExists(id))
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

        // POST: api/QuantityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuantityTypes>> PostQuantityTypes(QuantityTypes quantityTypes)
        {
          if (_context.QuantityTypes == null)
          {
              return Problem("Entity set 'DatabaseContext.QuantityTypes'  is null.");
          }
            _context.QuantityTypes.Add(quantityTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuantityTypes", new { id = quantityTypes.Id }, quantityTypes);
        }

        // DELETE: api/QuantityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuantityTypes(int id)
        {
            if (_context.QuantityTypes == null)
            {
                return NotFound();
            }
            var quantityTypes = await _context.QuantityTypes.FindAsync(id);
            if (quantityTypes == null)
            {
                return NotFound();
            }

            quantityTypes.ModificationDate = DateTime.Now;
            quantityTypes.IsActive = false;
            await PutQuantityTypes(id, quantityTypes);

            return NoContent();
        }

        private bool QuantityTypesExists(int id)
        {
            return (_context.QuantityTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
