using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RolesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
          if (_context.Roles == null)
          {
              return NotFound();
          }
            return await _context.Roles.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRoles(int id)
        {
          if (_context.Roles == null)
          {
              return NotFound();
          }
            var roles = await _context.Roles.FindAsync(id);

            if (roles == null)
            {
                return NotFound();
            }

            return roles;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, Roles roles)
        {
            if (id != roles.Id)
            {
                return BadRequest();
            }

            _context.Entry(roles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Roles>> PostRoles(Roles roles)
        {
          if (_context.Roles == null)
          {
              return Problem("Entity set 'DatabaseContext.Roles'  is null.");
          }
            _context.Roles.Add(roles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoles", new { id = roles.Id }, roles);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var roles = await _context.Roles.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            roles.ModificationDate = DateTime.Now;
            roles.IsActive = false;
            await PutRoles(id, roles);

            return NoContent();
        }

        private bool RolesExists(int id)
        {
            return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
