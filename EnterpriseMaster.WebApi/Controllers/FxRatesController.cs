using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FxRatesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FxRatesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/FxRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FxRates>>> GetFxRates()
        {
          if (_context.FxRates == null)
          {
              return NotFound();
          }
            return await _context.FxRates.ToListAsync();
        }

        // GET: api/FxRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FxRates>> GetFxRates(int id)
        {
          if (_context.FxRates == null)
          {
              return NotFound();
          }
            var fxRates = await _context.FxRates.FindAsync(id);

            if (fxRates == null)
            {
                return NotFound();
            }

            return fxRates;
        }

        // PUT: api/FxRates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFxRates(int id, FxRates fxRates)
        {
            if (id != fxRates.Id)
            {
                return BadRequest();
            }

            _context.Entry(fxRates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FxRatesExists(id))
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

        // POST: api/FxRates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FxRates>> PostFxRates(FxRates fxRates)
        {
          if (_context.FxRates == null)
          {
              return Problem("Entity set 'DatabaseContext.FxRates'  is null.");
          }
            _context.FxRates.Add(fxRates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFxRates", new { id = fxRates.Id }, fxRates);
        }

        // DELETE: api/FxRates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFxRates(int id)
        {
            if (_context.FxRates == null)
            {
                return NotFound();
            }
            var fxRates = await _context.FxRates.FindAsync(id);
            if (fxRates == null)
            {
                return NotFound();
            }

            fxRates.ModificationDate = DateTime.Now;
            fxRates.IsActive = false;
            await PutFxRates(id, fxRates);

            return NoContent();
        }

        private bool FxRatesExists(int id)
        {
            return (_context.FxRates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
