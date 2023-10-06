using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationBookmarksController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ApplicationBookmarksController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationBookmarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationBookmarks>>> GetApplicationBookmarks()
        {
          if (_context.ApplicationBookmarks == null)
          {
              return NotFound();
          }
            return await _context.ApplicationBookmarks.ToListAsync();
        }

        // GET: api/ApplicationBookmarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationBookmarks>> GetApplicationBookmarks(int id)
        {
          if (_context.ApplicationBookmarks == null)
          {
              return NotFound();
          }
            var applicationBookmarks = await _context.ApplicationBookmarks.FindAsync(id);

            if (applicationBookmarks == null)
            {
                return NotFound();
            }

            return applicationBookmarks;
        }

        // PUT: api/ApplicationBookmarks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationBookmarks(int id, ApplicationBookmarks applicationBookmarks)
        {
            if (id != applicationBookmarks.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationBookmarks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationBookmarksExists(id))
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

        // POST: api/ApplicationBookmarks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationBookmarks>> PostApplicationBookmarks(ApplicationBookmarks applicationBookmarks)
        {
          if (_context.ApplicationBookmarks == null)
          {
              return Problem("Entity set 'DatabaseContext.ApplicationBookmarks'  is null.");
          }
            _context.ApplicationBookmarks.Add(applicationBookmarks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationBookmarks", new { id = applicationBookmarks.Id }, applicationBookmarks);
        }

        // DELETE: api/ApplicationBookmarks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationBookmarks(int id)
        {
            if (_context.ApplicationBookmarks == null)
            {
                return NotFound();
            }
            var applicationBookmarks = await _context.ApplicationBookmarks.FindAsync(id);
            if (applicationBookmarks == null)
            {
                return NotFound();
            }

            _context.ApplicationBookmarks.Remove(applicationBookmarks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationBookmarksExists(int id)
        {
            return (_context.ApplicationBookmarks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
