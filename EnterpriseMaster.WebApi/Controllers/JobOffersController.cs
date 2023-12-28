using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class JobOffersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public JobOffersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/JobOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOffers>>> GetJobOffers()
        {
          if (_context.JobOffers == null)
          {
              return NotFound();
          }
            return await _context.JobOffers.ToListAsync();
        }

        // GET: api/JobOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobOffers>> GetJobOffers(int id)
        {
          if (_context.JobOffers == null)
          {
              return NotFound();
          }
            var jobOffers = await _context.JobOffers.FindAsync(id);

            if (jobOffers == null)
            {
                return NotFound();
            }

            return jobOffers;
        }

        // PUT: api/JobOffers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobOffers(int id, JobOffers jobOffers)
        {
            if (id != jobOffers.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobOffers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOffersExists(id))
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

        // POST: api/JobOffers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobOffers>> PostJobOffers(JobOffers jobOffers)
        {
          if (_context.JobOffers == null)
          {
              return Problem("Entity set 'DatabaseContext.JobOffers'  is null.");
          }
            _context.JobOffers.Add(jobOffers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobOffers", new { id = jobOffers.Id }, jobOffers);
        }

        // DELETE: api/JobOffers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobOffers(int id)
        {
            if (_context.JobOffers == null)
            {
                return NotFound();
            }
            var jobOffers = await _context.JobOffers.FindAsync(id);
            if (jobOffers == null)
            {
                return NotFound();
            }

            jobOffers.ModificationDate = DateTime.Now;
            jobOffers.IsActive = false;
            await PutJobOffers(id, jobOffers);

            return NoContent();
        }

        private bool JobOffersExists(int id)
        {
            return (_context.JobOffers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
