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
    public class CustomerInformationsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CustomerInformationsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CustomerInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInformation>>> GetCustomerInformation()
        {
          if (_context.CustomerInformation == null)
          {
              return NotFound();
          }
            return await _context.CustomerInformation.ToListAsync();
        }

        // GET: api/CustomerInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInformation>> GetCustomerInformation(int id)
        {
          if (_context.CustomerInformation == null)
          {
              return NotFound();
          }
            var customerInformation = await _context.CustomerInformation.FindAsync(id);

            if (customerInformation == null)
            {
                return NotFound();
            }

            return customerInformation;
        }

        // PUT: api/CustomerInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerInformation(int id, CustomerInformation customerInformation)
        {
            if (id != customerInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInformationExists(id))
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

        // POST: api/CustomerInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerInformation>> PostCustomerInformation(CustomerInformation customerInformation)
        {
          if (_context.CustomerInformation == null)
          {
              return Problem("Entity set 'DatabaseContext.CustomerInformation'  is null.");
          }
            _context.CustomerInformation.Add(customerInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerInformation", new { id = customerInformation.Id }, customerInformation);
        }

        // DELETE: api/CustomerInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerInformation(int id)
        {
            if (_context.CustomerInformation == null)
            {
                return NotFound();
            }
            var customerInformation = await _context.CustomerInformation.FindAsync(id);
            if (customerInformation == null)
            {
                return NotFound();
            }

            _context.CustomerInformation.Remove(customerInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerInformationExists(int id)
        {
            return (_context.CustomerInformation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
