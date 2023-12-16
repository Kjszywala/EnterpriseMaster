using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserRolesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UserRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoles>>> GetUserRoles()
        {
          if (_context.UserRoles == null)
          {
              return NotFound();
          }
            return await _context.UserRoles.ToListAsync();
        }

        // GET: api/UserRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoles>> GetUserRoles(int id)
        {
          if (_context.UserRoles == null)
          {
              return NotFound();
          }
            var userRoles = await _context.UserRoles.FindAsync(id);

            if (userRoles == null)
            {
                return NotFound();
            }

            return userRoles;
        }

        // PUT: api/UserRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRoles(int id, UserRoles userRoles)
        {
            if (id != userRoles.Id)
            {
                return BadRequest();
            }

            _context.Entry(userRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRolesExists(id))
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

        // POST: api/UserRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRoles>> PostUserRoles(UserRoles userRoles)
        {
          if (_context.UserRoles == null)
          {
              return Problem("Entity set 'DatabaseContext.UserRoles'  is null.");
          }
            _context.UserRoles.Add(userRoles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRoles", new { id = userRoles.Id }, userRoles);
        }

        // DELETE: api/UserRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRoles(int id)
        {
            if (_context.UserRoles == null)
            {
                return NotFound();
            }
            var userRoles = await _context.UserRoles.FindAsync(id);
            if (userRoles == null)
            {
                return NotFound();
            }

            userRoles.ModificationDate = DateTime.Now;
            userRoles.IsActive = false;
            await PutUserRoles(id, userRoles);

            return NoContent();
        }

        private bool UserRolesExists(int id)
        {
            return (_context.UserRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
