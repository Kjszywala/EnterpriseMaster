using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CompanyAddressesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CompanyAddressesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CompanyAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyAddress>>> GetCompanyAddress()
        {
          if (_context.CompanyAddress == null)
          {
              return NotFound();
          }
            return await _context.CompanyAddress.ToListAsync();
        }

        // GET: api/CompanyAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyAddress>> GetCompanyAddress(int id)
        {
          if (_context.CompanyAddress == null)
          {
              return NotFound();
          }
            var companyAddress = await _context.CompanyAddress.FindAsync(id);

            if (companyAddress == null)
            {
                return NotFound();
            }

            return companyAddress;
        }

        // PUT: api/CompanyAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyAddress(int id, CompanyAddress companyAddress)
        {
            if (id != companyAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyAddressExists(id))
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

        // POST: api/CompanyAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyAddress>> PostCompanyAddress(CompanyAddress companyAddress)
        {
          if (_context.CompanyAddress == null)
          {
              return Problem("Entity set 'DatabaseContext.CompanyAddress'  is null.");
          }
            _context.CompanyAddress.Add(companyAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyAddress", new { id = companyAddress.Id }, companyAddress);
        }

        // DELETE: api/CompanyAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyAddress(int id)
        {
            if (_context.CompanyAddress == null)
            {
                return NotFound();
            }
            var companyAddress = await _context.CompanyAddress.FindAsync(id);
            if (companyAddress == null)
            {
                return NotFound();
            }

            companyAddress.ModificationDate = DateTime.Now;
            companyAddress.IsActive = false;
            await PutCompanyAddress(id, companyAddress);

            return NoContent();
        }

        private bool CompanyAddressExists(int id)
        {
            return (_context.CompanyAddress?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
