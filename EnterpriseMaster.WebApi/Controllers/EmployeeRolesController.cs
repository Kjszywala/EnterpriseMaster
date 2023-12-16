using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeeRolesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EmployeeRolesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeRoles>>> GetEmployeeRoles()
        {
          if (_context.EmployeeRoles == null)
          {
              return NotFound();
          }
            return await _context.EmployeeRoles.ToListAsync();
        }

        // GET: api/EmployeeRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeRoles>> GetEmployeeRoles(int id)
        {
          if (_context.EmployeeRoles == null)
          {
              return NotFound();
          }
            var employeeRoles = await _context.EmployeeRoles.FindAsync(id);

            if (employeeRoles == null)
            {
                return NotFound();
            }

            return employeeRoles;
        }

        // PUT: api/EmployeeRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeRoles(int id, EmployeeRoles employeeRoles)
        {
            if (id != employeeRoles.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeRolesExists(id))
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

        // POST: api/EmployeeRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeRoles>> PostEmployeeRoles(EmployeeRoles employeeRoles)
        {
          if (_context.EmployeeRoles == null)
          {
              return Problem("Entity set 'DatabaseContext.EmployeeRoles'  is null.");
          }
            _context.EmployeeRoles.Add(employeeRoles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeRoles", new { id = employeeRoles.Id }, employeeRoles);
        }

        // DELETE: api/EmployeeRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeRoles(int id)
        {
            if (_context.EmployeeRoles == null)
            {
                return NotFound();
            }
            var employeeRoles = await _context.EmployeeRoles.FindAsync(id);
            if (employeeRoles == null)
            {
                return NotFound();
            }

            employeeRoles.ModificationDate = DateTime.Now;
            employeeRoles.IsActive = false;
            await PutEmployeeRoles(id, employeeRoles);

            return NoContent();
        }

        private bool EmployeeRolesExists(int id)
        {
            return (_context.EmployeeRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
