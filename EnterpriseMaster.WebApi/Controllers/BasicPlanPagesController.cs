using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BasicPlanPagesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BasicPlanPagesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/BasicPlanPages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicPlanPage>>> GetBasicPlanPage()
        {
          if (_context.BasicPlanPage == null)
          {
              return NotFound();
          }
            return await _context.BasicPlanPage.ToListAsync();
        }

        // GET: api/BasicPlanPages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicPlanPage>> GetBasicPlanPage(int id)
        {
          if (_context.BasicPlanPage == null)
          {
              return NotFound();
          }
            var basicPlanPage = await _context.BasicPlanPage.FindAsync(id);

            if (basicPlanPage == null)
            {
                return NotFound();
            }

            return basicPlanPage;
        }

        // PUT: api/BasicPlanPages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasicPlanPage(int id, BasicPlanPage basicPlanPage)
        {
            if (id != basicPlanPage.Id)
            {
                return BadRequest();
            }

            _context.Entry(basicPlanPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasicPlanPageExists(id))
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

        // POST: api/BasicPlanPages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasicPlanPage>> PostBasicPlanPage(BasicPlanPage basicPlanPage)
        {
          if (_context.BasicPlanPage == null)
          {
              return Problem("Entity set 'DatabaseContext.BasicPlanPage'  is null.");
          }
            _context.BasicPlanPage.Add(basicPlanPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasicPlanPage", new { id = basicPlanPage.Id }, basicPlanPage);
        }

        // DELETE: api/BasicPlanPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasicPlanPage(int id)
        {
            if (_context.BasicPlanPage == null)
            {
                return NotFound();
            }
            var basicPlanPage = await _context.BasicPlanPage.FindAsync(id);
            if (basicPlanPage == null)
            {
                return NotFound();
            }

            _context.BasicPlanPage.Remove(basicPlanPage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasicPlanPageExists(int id)
        {
            return (_context.BasicPlanPage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
