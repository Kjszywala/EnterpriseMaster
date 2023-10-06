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
    public class EmployeeAddressesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EmployeeAddressesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeAddresses>>> GetEmployeeAddresses()
        {
          if (_context.EmployeeAddresses == null)
          {
              return NotFound();
          }
            return await _context.EmployeeAddresses.ToListAsync();
        }

        // GET: api/EmployeeAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeAddresses>> GetEmployeeAddresses(int id)
        {
          if (_context.EmployeeAddresses == null)
          {
              return NotFound();
          }
            var employeeAddresses = await _context.EmployeeAddresses.FindAsync(id);

            if (employeeAddresses == null)
            {
                return NotFound();
            }

            return employeeAddresses;
        }

        // PUT: api/EmployeeAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeAddresses(int id, EmployeeAddresses employeeAddresses)
        {
            if (id != employeeAddresses.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeAddresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeAddressesExists(id))
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

        // POST: api/EmployeeAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeAddresses>> PostEmployeeAddresses(EmployeeAddresses employeeAddresses)
        {
          if (_context.EmployeeAddresses == null)
          {
              return Problem("Entity set 'DatabaseContext.EmployeeAddresses'  is null.");
          }
            _context.EmployeeAddresses.Add(employeeAddresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeAddresses", new { id = employeeAddresses.Id }, employeeAddresses);
        }

        // DELETE: api/EmployeeAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAddresses(int id)
        {
            if (_context.EmployeeAddresses == null)
            {
                return NotFound();
            }
            var employeeAddresses = await _context.EmployeeAddresses.FindAsync(id);
            if (employeeAddresses == null)
            {
                return NotFound();
            }

            _context.EmployeeAddresses.Remove(employeeAddresses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeAddressesExists(int id)
        {
            return (_context.EmployeeAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
