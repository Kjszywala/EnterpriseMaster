using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ErrorLogsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ErrorLogsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ErrorLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErrorLogs>>> GetErrorLogs()
        {
          if (_context.ErrorLogs == null)
          {
              return NotFound();
          }
            return await _context.ErrorLogs.ToListAsync();
        }

        // GET: api/ErrorLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErrorLogs>> GetErrorLogs(int id)
        {
          if (_context.ErrorLogs == null)
          {
              return NotFound();
          }
            var errorLogs = await _context.ErrorLogs.FindAsync(id);

            if (errorLogs == null)
            {
                return NotFound();
            }

            return errorLogs;
        }

        // PUT: api/ErrorLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErrorLogs(int id, ErrorLogs errorLogs)
        {
            if (id != errorLogs.Id)
            {
                return BadRequest();
            }

            _context.Entry(errorLogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorLogsExists(id))
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

        // POST: api/ErrorLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ErrorLogs>> PostErrorLogs(ErrorLogs errorLogs)
        {
          if (_context.ErrorLogs == null)
          {
              return Problem("Entity set 'DatabaseContext.ErrorLogs'  is null.");
          }
            _context.ErrorLogs.Add(errorLogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErrorLogs", new { id = errorLogs.Id }, errorLogs);
        }

        // DELETE: api/ErrorLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErrorLogs(int id)
        {
            if (_context.ErrorLogs == null)
            {
                return NotFound();
            }
            var errorLogs = await _context.ErrorLogs.FindAsync(id);
            if (errorLogs == null)
            {
                return NotFound();
            }

            _context.ErrorLogs.Remove(errorLogs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ErrorLogsExists(int id)
        {
            return (_context.ErrorLogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
