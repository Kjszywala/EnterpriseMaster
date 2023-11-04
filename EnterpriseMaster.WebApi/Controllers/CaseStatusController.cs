using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CaseStatusController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CaseStatusController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CaseStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseStatus>>> GetCaseStatus()
        {
          if (_context.CaseStatus == null)
          {
              return NotFound();
          }
            return await _context.CaseStatus.ToListAsync();
        }

        // GET: api/CaseStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseStatus>> GetCaseStatus(int id)
        {
          if (_context.CaseStatus == null)
          {
              return NotFound();
          }
            var caseStatus = await _context.CaseStatus.FindAsync(id);

            if (caseStatus == null)
            {
                return NotFound();
            }

            return caseStatus;
        }

        // PUT: api/CaseStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseStatus(int id, CaseStatus caseStatus)
        {
            if (id != caseStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseStatusExists(id))
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

        // POST: api/CaseStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaseStatus>> PostCaseStatus(CaseStatus caseStatus)
        {
          if (_context.CaseStatus == null)
          {
              return Problem("Entity set 'DatabaseContext.CaseStatus'  is null.");
          }
            _context.CaseStatus.Add(caseStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseStatus", new { id = caseStatus.Id }, caseStatus);
        }

        // DELETE: api/CaseStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseStatus(int id)
        {
            if (_context.CaseStatus == null)
            {
                return NotFound();
            }
            var caseStatus = await _context.CaseStatus.FindAsync(id);
            if (caseStatus == null)
            {
                return NotFound();
            }

            _context.CaseStatus.Remove(caseStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseStatusExists(int id)
        {
            return (_context.CaseStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
