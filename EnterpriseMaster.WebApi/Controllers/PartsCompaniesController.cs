using EnterpriseMaster.DbServices.Migrations;
using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PartsCompaniesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PartsCompaniesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PartsCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartsCompanies>>> GetPartsCompanies()
        {
            if (_context.PartsCompanies == null)
            {
                return NotFound();
            }
            return await _context.PartsCompanies.ToListAsync();
        }

        // GET: api/PartsCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartsCompanies>> GetPartsCompanies(int id)
        {
            if (_context.PartsCompanies == null)
            {
                return NotFound();
            }
            var partsCompanies = await _context.PartsCompanies.FindAsync(id);

            if (partsCompanies == null)
            {
                return NotFound();
            }

            return partsCompanies;
        }

        // PUT: api/PartsCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartsCompanies(int id, PartsCompanies partsCompanies)
        {
            if (id != partsCompanies.Id)
            {
                return BadRequest();
            }

            _context.Entry(partsCompanies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartsCompaniesExists(id))
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

        // POST: api/PartsCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartsCompanies>> PostPartsCompanies(PartsCompanies partsCompanies)
        {
            if (_context.PartsCompanies == null)
            {
                return Problem("Entity set 'DatabaseContext.PartsCompanies'  is null.");
            }
            _context.PartsCompanies.Add(partsCompanies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartsCompanies", new { id = partsCompanies.Id }, partsCompanies);
        }

        // DELETE: api/PartsCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartsCompanies(int id)
        {
            if (_context.PartsCompanies == null)
            {
                return NotFound();
            }
            var partsCompanies = await _context.PartsCompanies.FindAsync(id);
            if (partsCompanies == null)
            {
                return NotFound();
            }

            partsCompanies.ModificationDate = DateTime.Now;
            partsCompanies.IsActive = false;
            await PutPartsCompanies(id, partsCompanies);

            return NoContent();
        }

        private bool PartsCompaniesExists(int id)
        {
            return (_context.PartsCompanies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
