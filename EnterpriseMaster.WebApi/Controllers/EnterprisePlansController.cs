using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EnterprisePlansController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EnterprisePlansController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EnterprisePlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnterprisePlan>>> GetEnterprisePlan()
        {
          if (_context.EnterprisePlan == null)
          {
              return NotFound();
          }
            return await _context.EnterprisePlan.ToListAsync();
        }

        // GET: api/EnterprisePlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnterprisePlan>> GetEnterprisePlan(int id)
        {
          if (_context.EnterprisePlan == null)
          {
              return NotFound();
          }
            var enterprisePlan = await _context.EnterprisePlan.FindAsync(id);

            if (enterprisePlan == null)
            {
                return NotFound();
            }

            return enterprisePlan;
        }

        // PUT: api/EnterprisePlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnterprisePlan(int id, EnterprisePlan enterprisePlan)
        {
            if (id != enterprisePlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(enterprisePlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnterprisePlanExists(id))
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

        // POST: api/EnterprisePlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnterprisePlan>> PostEnterprisePlan(EnterprisePlan enterprisePlan)
        {
          if (_context.EnterprisePlan == null)
          {
              return Problem("Entity set 'DatabaseContext.EnterprisePlan'  is null.");
          }
            _context.EnterprisePlan.Add(enterprisePlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnterprisePlan", new { id = enterprisePlan.Id }, enterprisePlan);
        }

        // DELETE: api/EnterprisePlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnterprisePlan(int id)
        {
            if (_context.EnterprisePlan == null)
            {
                return NotFound();
            }
            var enterprisePlan = await _context.EnterprisePlan.FindAsync(id);
            if (enterprisePlan == null)
            {
                return NotFound();
            }

            _context.EnterprisePlan.Remove(enterprisePlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnterprisePlanExists(int id)
        {
            return (_context.EnterprisePlan?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
