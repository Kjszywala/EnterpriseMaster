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
    public class SuppliersAddressesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SuppliersAddressesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SuppliersAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuppliersAddresses>>> GetSuppliersAddresses()
        {
          if (_context.SuppliersAddresses == null)
          {
              return NotFound();
          }
            return await _context.SuppliersAddresses.ToListAsync();
        }

        // GET: api/SuppliersAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuppliersAddresses>> GetSuppliersAddresses(int id)
        {
          if (_context.SuppliersAddresses == null)
          {
              return NotFound();
          }
            var suppliersAddresses = await _context.SuppliersAddresses.FindAsync(id);

            if (suppliersAddresses == null)
            {
                return NotFound();
            }

            return suppliersAddresses;
        }

        // PUT: api/SuppliersAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuppliersAddresses(int id, SuppliersAddresses suppliersAddresses)
        {
            if (id != suppliersAddresses.Id)
            {
                return BadRequest();
            }

            _context.Entry(suppliersAddresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuppliersAddressesExists(id))
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

        // POST: api/SuppliersAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuppliersAddresses>> PostSuppliersAddresses(SuppliersAddresses suppliersAddresses)
        {
          if (_context.SuppliersAddresses == null)
          {
              return Problem("Entity set 'DatabaseContext.SuppliersAddresses'  is null.");
          }
            _context.SuppliersAddresses.Add(suppliersAddresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuppliersAddresses", new { id = suppliersAddresses.Id }, suppliersAddresses);
        }

        // DELETE: api/SuppliersAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuppliersAddresses(int id)
        {
            if (_context.SuppliersAddresses == null)
            {
                return NotFound();
            }
            var suppliersAddresses = await _context.SuppliersAddresses.FindAsync(id);
            if (suppliersAddresses == null)
            {
                return NotFound();
            }

            _context.SuppliersAddresses.Remove(suppliersAddresses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuppliersAddressesExists(int id)
        {
            return (_context.SuppliersAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
