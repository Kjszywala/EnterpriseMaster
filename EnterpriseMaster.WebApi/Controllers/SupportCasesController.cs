using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SupportCasesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SupportCasesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SupportCases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportCases>>> GetSupportCases()
        {
          if (_context.SupportCases == null)
          {
              return NotFound();
          }
            return await _context.SupportCases.ToListAsync();
        }

        // GET: api/SupportCases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportCases>> GetSupportCases(int id)
        {
          if (_context.SupportCases == null)
          {
              return NotFound();
          }
            var supportCases = await _context.SupportCases.FindAsync(id);

            if (supportCases == null)
            {
                return NotFound();
            }

            return supportCases;
        }

        // PUT: api/SupportCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportCases(int id, SupportCases supportCases)
        {
            if (id != supportCases.Id)
            {
                return BadRequest();
            }

            _context.Entry(supportCases).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportCasesExists(id))
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

        // POST: api/SupportCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SupportCases>> PostSupportCases(SupportCases supportCases)
        {
          if (_context.SupportCases == null)
          {
              return Problem("Entity set 'DatabaseContext.SupportCases'  is null.");
          }
            _context.SupportCases.Add(supportCases);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupportCases", new { id = supportCases.Id }, supportCases);
        }

        // DELETE: api/SupportCases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportCases(int id)
        {
            if (_context.SupportCases == null)
            {
                return NotFound();
            }
            var supportCases = await _context.SupportCases.FindAsync(id);
            if (supportCases == null)
            {
                return NotFound();
            }

            _context.SupportCases.Remove(supportCases);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupportCasesExists(int id)
        {
            return (_context.SupportCases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
