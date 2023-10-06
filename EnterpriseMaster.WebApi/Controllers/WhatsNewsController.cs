using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class WhatsNewsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WhatsNewsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/WhatsNews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WhatsNew>>> GetWhatsNew()
        {
          if (_context.WhatsNew == null)
          {
              return NotFound();
          }
            return await _context.WhatsNew.ToListAsync();
        }

        // GET: api/WhatsNews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WhatsNew>> GetWhatsNew(int id)
        {
          if (_context.WhatsNew == null)
          {
              return NotFound();
          }
            var whatsNew = await _context.WhatsNew.FindAsync(id);

            if (whatsNew == null)
            {
                return NotFound();
            }

            return whatsNew;
        }

        // PUT: api/WhatsNews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWhatsNew(int id, WhatsNew whatsNew)
        {
            if (id != whatsNew.Id)
            {
                return BadRequest();
            }

            _context.Entry(whatsNew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WhatsNewExists(id))
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

        // POST: api/WhatsNews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WhatsNew>> PostWhatsNew(WhatsNew whatsNew)
        {
          if (_context.WhatsNew == null)
          {
              return Problem("Entity set 'DatabaseContext.WhatsNew'  is null.");
          }
            _context.WhatsNew.Add(whatsNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWhatsNew", new { id = whatsNew.Id }, whatsNew);
        }

        // DELETE: api/WhatsNews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhatsNew(int id)
        {
            if (_context.WhatsNew == null)
            {
                return NotFound();
            }
            var whatsNew = await _context.WhatsNew.FindAsync(id);
            if (whatsNew == null)
            {
                return NotFound();
            }

            whatsNew.ModificationDate = DateTime.Now;
            whatsNew.IsActive = true;
            await PutWhatsNew(id, whatsNew);

            return NoContent();
        }

        private bool WhatsNewExists(int id)
        {
            return (_context.WhatsNew?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
