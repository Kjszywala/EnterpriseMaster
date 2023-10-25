using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProfessionalPlanPagesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProfessionalPlanPagesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ProfessionalPlanPages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionalPlanPage>>> GetProfessionalPlanPage()
        {
          if (_context.ProfessionalPlanPage == null)
          {
              return NotFound();
          }
            return await _context.ProfessionalPlanPage.ToListAsync();
        }

        // GET: api/ProfessionalPlanPages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessionalPlanPage>> GetProfessionalPlanPage(int id)
        {
          if (_context.ProfessionalPlanPage == null)
          {
              return NotFound();
          }
            var professionalPlanPage = await _context.ProfessionalPlanPage.FindAsync(id);

            if (professionalPlanPage == null)
            {
                return NotFound();
            }

            return professionalPlanPage;
        }

        // PUT: api/ProfessionalPlanPages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessionalPlanPage(int id, ProfessionalPlanPage professionalPlanPage)
        {
            if (id != professionalPlanPage.Id)
            {
                return BadRequest();
            }

            _context.Entry(professionalPlanPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionalPlanPageExists(id))
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

        // POST: api/ProfessionalPlanPages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfessionalPlanPage>> PostProfessionalPlanPage(ProfessionalPlanPage professionalPlanPage)
        {
          if (_context.ProfessionalPlanPage == null)
          {
              return Problem("Entity set 'DatabaseContext.ProfessionalPlanPage'  is null.");
          }
            _context.ProfessionalPlanPage.Add(professionalPlanPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessionalPlanPage", new { id = professionalPlanPage.Id }, professionalPlanPage);
        }

        // DELETE: api/ProfessionalPlanPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessionalPlanPage(int id)
        {
            if (_context.ProfessionalPlanPage == null)
            {
                return NotFound();
            }
            var professionalPlanPage = await _context.ProfessionalPlanPage.FindAsync(id);
            if (professionalPlanPage == null)
            {
                return NotFound();
            }

            _context.ProfessionalPlanPage.Remove(professionalPlanPage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessionalPlanPageExists(int id)
        {
            return (_context.ProfessionalPlanPage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
