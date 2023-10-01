using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApplicationServicesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ApplicationServicesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationServices>>> GetApplicationServices()
        {
          if (_context.ApplicationServices == null)
          {
              return NotFound();
          }
            return await _context.ApplicationServices.ToListAsync();
        }

        // GET: api/ApplicationServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationServices>> GetApplicationServices(int id)
        {
          if (_context.ApplicationServices == null)
          {
              return NotFound();
          }
            var applicationServices = await _context.ApplicationServices.FindAsync(id);

            if (applicationServices == null)
            {
                return NotFound();
            }

            return applicationServices;
        }

        // PUT: api/ApplicationServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationServices(int id, ApplicationServices applicationServices)
        {
            if (id != applicationServices.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationServices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationServicesExists(id))
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

        // POST: api/ApplicationServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationServices>> PostApplicationServices(ApplicationServices applicationServices)
        {
          if (_context.ApplicationServices == null)
          {
              return Problem("Entity set 'DatabaseContext.ApplicationServices'  is null.");
          }
            _context.ApplicationServices.Add(applicationServices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationServices", new { id = applicationServices.Id }, applicationServices);
        }

        // DELETE: api/ApplicationServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationServices(int id)
        {
            if (_context.ApplicationServices == null)
            {
                return NotFound();
            }
            var applicationServices = await _context.ApplicationServices.FindAsync(id);

            if (applicationServices == null)
            {
                return NotFound();
            }

            applicationServices.IsActive = false;
            applicationServices.ModificationDate = DateTime.Now;

            await PutApplicationServices(id, applicationServices);

            return Ok();
        }

        private bool ApplicationServicesExists(int id)
        {
            return (_context.ApplicationServices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
