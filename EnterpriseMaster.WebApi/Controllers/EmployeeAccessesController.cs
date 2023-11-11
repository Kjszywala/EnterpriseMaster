using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeeAccessesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EmployeeAccessesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeAccesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeAccesses>>> GetEmployeeAccesses()
        {
          if (_context.EmployeeAccesses == null)
          {
              return NotFound();
          }
            return await _context.EmployeeAccesses.ToListAsync();
        }

        // GET: api/EmployeeAccesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeAccesses>> GetEmployeeAccesses(int id)
        {
          if (_context.EmployeeAccesses == null)
          {
              return NotFound();
          }
            var employeeAccesses = await _context.EmployeeAccesses.FindAsync(id);

            if (employeeAccesses == null)
            {
                return NotFound();
            }

            return employeeAccesses;
        }

        // PUT: api/EmployeeAccesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeAccesses(int id, EmployeeAccesses employeeAccesses)
        {
            if (id != employeeAccesses.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeAccesses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeAccessesExists(id))
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

        // POST: api/EmployeeAccesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeAccesses>> PostEmployeeAccesses(EmployeeAccesses employeeAccesses)
        {
          if (_context.EmployeeAccesses == null)
          {
              return Problem("Entity set 'DatabaseContext.EmployeeAccesses'  is null.");
          }
            _context.EmployeeAccesses.Add(employeeAccesses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeAccesses", new { id = employeeAccesses.Id }, employeeAccesses);
        }

        // DELETE: api/EmployeeAccesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAccesses(int id)
        {
            if (_context.EmployeeAccesses == null)
            {
                return NotFound();
            }
            var employeeAccesses = await _context.EmployeeAccesses.FindAsync(id);
            if (employeeAccesses == null)
            {
                return NotFound();
            }

            _context.EmployeeAccesses.Remove(employeeAccesses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeAccessesExists(int id)
        {
            return (_context.EmployeeAccesses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
