using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TaskStatusController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TaskStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbServices.Models.Database.TaskStatus>>> GetTaskStatus()
        {
          if (_context.TaskStatus == null)
          {
              return NotFound();
          }
            return await _context.TaskStatus.ToListAsync();
        }

        // GET: api/TaskStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbServices.Models.Database.TaskStatus>> GetTaskStatus(int id)
        {
          if (_context.TaskStatus == null)
          {
              return NotFound();
          }
            var taskStatus = await _context.TaskStatus.FindAsync(id);

            if (taskStatus == null)
            {
                return NotFound();
            }

            return taskStatus;
        }

        // PUT: api/TaskStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskStatus(int id, DbServices.Models.Database.TaskStatus taskStatus)
        {
            if (id != taskStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskStatusExists(id))
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

        // POST: api/TaskStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DbServices.Models.Database.TaskStatus>> PostTaskStatus(DbServices.Models.Database.TaskStatus taskStatus)
        {
          if (_context.TaskStatus == null)
          {
              return Problem("Entity set 'DatabaseContext.TaskStatus'  is null.");
          }
            _context.TaskStatus.Add(taskStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskStatus", new { id = taskStatus.Id }, taskStatus);
        }

        // DELETE: api/TaskStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskStatus(int id)
        {
            if (_context.TaskStatus == null)
            {
                return NotFound();
            }
            var taskStatus = await _context.TaskStatus.FindAsync(id);
            if (taskStatus == null)
            {
                return NotFound();
            }

            _context.TaskStatus.Remove(taskStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskStatusExists(int id)
        {
            return (_context.TaskStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
