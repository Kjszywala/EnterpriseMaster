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
    public class UsersAdressesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UsersAdressesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UsersAdresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersAdresses>>> GetUsersAdresses()
        {
          if (_context.UsersAdresses == null)
          {
              return NotFound();
          }
            return await _context.UsersAdresses.ToListAsync();
        }

        // GET: api/UsersAdresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersAdresses>> GetUsersAdresses(int id)
        {
          if (_context.UsersAdresses == null)
          {
              return NotFound();
          }
            var usersAdresses = await _context.UsersAdresses.FindAsync(id);

            if (usersAdresses == null)
            {
                return NotFound();
            }

            return usersAdresses;
        }

        // PUT: api/UsersAdresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersAdresses(int id, UsersAdresses usersAdresses)
        {
            if (id != usersAdresses.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersAdresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersAdressesExists(id))
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

        // POST: api/UsersAdresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsersAdresses>> PostUsersAdresses(UsersAdresses usersAdresses)
        {
          if (_context.UsersAdresses == null)
          {
              return Problem("Entity set 'DatabaseContext.UsersAdresses'  is null.");
          }
            _context.UsersAdresses.Add(usersAdresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersAdresses", new { id = usersAdresses.Id }, usersAdresses);
        }

        // DELETE: api/UsersAdresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersAdresses(int id)
        {
            if (_context.UsersAdresses == null)
            {
                return NotFound();
            }
            var usersAdresses = await _context.UsersAdresses.FindAsync(id);
            if (usersAdresses == null)
            {
                return NotFound();
            }

            _context.UsersAdresses.Remove(usersAdresses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersAdressesExists(int id)
        {
            return (_context.UsersAdresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
