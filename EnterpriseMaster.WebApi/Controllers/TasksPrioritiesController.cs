using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TasksPrioritiesController : Controller
    {
        private readonly DatabaseContext _context;

        public TasksPrioritiesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TasksPriorities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TasksPriorities>>> GetTasksPriorities()
        {
            if (_context.TasksPriorities == null)
            {
                return NotFound();
            }
            return await _context.TasksPriorities.ToListAsync();
        }

        // GET: api/TasksPriorities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TasksPriorities>> GetTasksPriorities(int id)
        {
            if (_context.TasksPriorities == null)
            {
                return NotFound();
            }
            var tasks = await _context.TasksPriorities.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return tasks;
        }

        // PUT: api/TasksPriorities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasksPriorities(int id, TasksPriorities tasks)
        {
            if (id != tasks.Id)
            {
                return BadRequest();
            }

            _context.Entry(tasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksPrioritiesExists(id))
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

        // POST: api/TasksPriorities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TasksPriorities>> PostTasks(TasksPriorities tasks)
        {
            if (_context.TasksPriorities == null)
            {
                return Problem("Entity set 'DatabaseContext.Tasks'  is null.");
            }
            _context.TasksPriorities.Add(tasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasksPriorities", new { id = tasks.Id }, tasks);
        }

        // DELETE: api/TasksPriorities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasksPriorities(int id)
        {
            if (_context.TasksPriorities == null)
            {
                return NotFound();
            }
            var tasks = await _context.TasksPriorities.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }

            tasks.ModificationDate = DateTime.Now;
            tasks.IsActive = false;
            await PutTasksPriorities(id, tasks);

            return NoContent();
        }

        private bool TasksPrioritiesExists(int id)
        {
            return (_context.TasksPriorities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
