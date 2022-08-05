using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetToolAPI.Models;

namespace PetToolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ActivityTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityType>>> GetActivityTypes()
        {
            if (_context.ActivityTypes == null)
            {
                return NotFound();
            }
            return await _context.ActivityTypes.ToListAsync();
        }

        // GET: api/ActivityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityType>> GetActivityType(long id)
        {
            if (_context.ActivityTypes == null)
            {
                return NotFound();
            }
            var ActivityType = await _context.ActivityTypes.FindAsync(id);

            if (ActivityType == null)
            {
                return NotFound();
            }

            return ActivityType;
        }

        // PUT: api/ActivityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityType(long id, ActivityType record)
        {
            if (id != record.Id)
            {
                return BadRequest();
            }

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTypeExists(id))
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

        // POST: api/ActivityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityType>> PostActivityType(ActivityType record)
        {
            if (_context.ActivityTypes == null)
            {
                return Problem("Entity set '_context.ActivityTypes'  is null.");
            }

            _context.ActivityTypes.Add(record);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetActivityType", new { id = ActivityType.ID }, ActivityType);
            return CreatedAtAction(nameof(GetActivityType), new { id = record.Id }, record);
        }

        // DELETE: api/ActivityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityType(long id)
        {
            if (_context.ActivityTypes == null)
            {
                return NotFound();
            }
            
            var record = await _context.ActivityTypes.FindAsync(id);
            
            if (record == null)
            {
                return NotFound();
            }

            _context.ActivityTypes.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityTypeExists(long id)
        {
            return (_context.ActivityTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
