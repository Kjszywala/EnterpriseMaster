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
    public class MainPagesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MainPagesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MainPages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainPages>>> GetMainPages()
        {
          if (_context.MainPages == null)
          {
              return NotFound();
          }
            return await _context.MainPages.ToListAsync();
        }

        // GET: api/MainPages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainPages>> GetMainPages(int id)
        {
          if (_context.MainPages == null)
          {
              return NotFound();
          }
            var mainPages = await _context.MainPages.FindAsync(id);

            if (mainPages == null)
            {
                return NotFound();
            }

            return mainPages;
        }

        // PUT: api/MainPages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainPages(int id, MainPages mainPages)
        {
            if (id != mainPages.Id)
            {
                return BadRequest();
            }

            _context.Entry(mainPages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainPagesExists(id))
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

        // POST: api/MainPages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MainPages>> PostMainPages(MainPages mainPages)
        {
          if (_context.MainPages == null)
          {
              return Problem("Entity set 'DatabaseContext.MainPages'  is null.");
          }
            _context.MainPages.Add(mainPages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMainPages", new { id = mainPages.Id }, mainPages);
        }

        // DELETE: api/MainPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMainPages(int id)
        {
            if (_context.MainPages == null)
            {
                return NotFound();
            }
            var mainPages = await _context.MainPages.FindAsync(id);
            if (mainPages == null)
            {
                return NotFound();
            }

            _context.MainPages.Remove(mainPages);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MainPagesExists(int id)
        {
            return (_context.MainPages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
