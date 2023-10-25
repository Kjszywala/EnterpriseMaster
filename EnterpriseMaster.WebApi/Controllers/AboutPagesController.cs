using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AboutPagesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AboutPagesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AboutPages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutPage>>> GetAboutPage()
        {
          if (_context.AboutPage == null)
          {
              return NotFound();
          }
            return await _context.AboutPage.ToListAsync();
        }

        // GET: api/AboutPages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AboutPage>> GetAboutPage(int id)
        {
          if (_context.AboutPage == null)
          {
              return NotFound();
          }
            var aboutPage = await _context.AboutPage.FindAsync(id);

            if (aboutPage == null)
            {
                return NotFound();
            }

            return aboutPage;
        }

        // PUT: api/AboutPages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAboutPage(int id, AboutPage aboutPage)
        {
            if (id != aboutPage.Id)
            {
                return BadRequest();
            }

            _context.Entry(aboutPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutPageExists(id))
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

        // POST: api/AboutPages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AboutPage>> PostAboutPage(AboutPage aboutPage)
        {
          if (_context.AboutPage == null)
          {
              return Problem("Entity set 'DatabaseContext.AboutPage'  is null.");
          }
            _context.AboutPage.Add(aboutPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAboutPage", new { id = aboutPage.Id }, aboutPage);
        }

        // DELETE: api/AboutPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutPage(int id)
        {
            if (_context.AboutPage == null)
            {
                return NotFound();
            }
            var aboutPage = await _context.AboutPage.FindAsync(id);
            if (aboutPage == null)
            {
                return NotFound();
            }

            _context.AboutPage.Remove(aboutPage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AboutPageExists(int id)
        {
            return (_context.AboutPage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
