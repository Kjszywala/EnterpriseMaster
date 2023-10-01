using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApplicationFeaturesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ApplicationFeaturesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationFeatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationFeatures>>> GetApplicationFeatures()
        {
          if (_context.ApplicationFeatures == null)
          {
              return NotFound();
          }
            return await _context.ApplicationFeatures.ToListAsync();
        }

        // GET: api/ApplicationFeatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationFeatures>> GetApplicationFeatures(int id)
        {
          if (_context.ApplicationFeatures == null)
          {
              return NotFound();
          }
            var applicationFeatures = await _context.ApplicationFeatures.FindAsync(id);

            if (applicationFeatures == null)
            {
                return NotFound();
            }

            return applicationFeatures;
        }

        // PUT: api/ApplicationFeatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationFeatures(int id, ApplicationFeatures applicationFeatures)
        {
            if (id != applicationFeatures.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationFeatures).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationFeaturesExists(id))
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

        // POST: api/ApplicationFeatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationFeatures>> PostApplicationFeatures(ApplicationFeatures applicationFeatures)
        {
          if (_context.ApplicationFeatures == null)
          {
              return Problem("Entity set 'DatabaseContext.ApplicationFeatures'  is null.");
          }
            _context.ApplicationFeatures.Add(applicationFeatures);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationFeatures", new { id = applicationFeatures.Id }, applicationFeatures);
        }

        // DELETE: api/ApplicationFeatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationFeatures(int id)
        {
            if (_context.ApplicationFeatures == null)
            {
                return NotFound();
            }
            var applicationFeatures = await _context.ApplicationFeatures.FindAsync(id);
            if (applicationFeatures == null)
            {
                return NotFound();
            }

            await PutApplicationFeatures(id, applicationFeatures);

            return NoContent();
        }

        private bool ApplicationFeaturesExists(int id)
        {
            return (_context.ApplicationFeatures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
