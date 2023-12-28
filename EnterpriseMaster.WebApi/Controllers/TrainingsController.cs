using EnterpriseMaster.DbServices.Models;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TrainingsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Trainings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainings>>> GetTrainings()
        {
          if (_context.Trainings == null)
          {
              return NotFound();
          }
            return await _context.Trainings.ToListAsync();
        }

        // GET: api/Trainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainings>> GetTrainings(int id)
        {
          if (_context.Trainings == null)
          {
              return NotFound();
          }
            var trainings = await _context.Trainings.FindAsync(id);

            if (trainings == null)
            {
                return NotFound();
            }

            return trainings;
        }

        // PUT: api/Trainings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainings(int id, Trainings trainings)
        {
            if (id != trainings.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingsExists(id))
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

        // POST: api/Trainings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trainings>> PostTrainings(Trainings trainings)
        {
          if (_context.Trainings == null)
          {
              return Problem("Entity set 'DatabaseContext.Trainings'  is null.");
          }
            _context.Trainings.Add(trainings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainings", new { id = trainings.Id }, trainings);
        }

        // DELETE: api/Trainings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainings(int id)
        {
            if (_context.Trainings == null)
            {
                return NotFound();
            }
            var trainings = await _context.Trainings.FindAsync(id);
            if (trainings == null)
            {
                return NotFound();
            }

            trainings.ModificationDate = DateTime.Now;
            trainings.IsActive = false;
            await PutTrainings(id, trainings);

            return NoContent();
        }

        private bool TrainingsExists(int id)
        {
            return (_context.Trainings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
