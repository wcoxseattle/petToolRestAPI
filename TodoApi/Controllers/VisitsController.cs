using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetToolAPI.Data;
using PetToolAPI.Models;

namespace PetToolAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VisitsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VisitsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            if (_context.People == null)
            {
                return NotFound();
            }

            return await _context.People.ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(long id)
        {
            if (_context.People == null)
            {
                return NotFound();
            }
            var record = await _context.People.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(long id, Person record)
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
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person record)
        {
            if (_context.People == null)
            {
                return Problem("Entity set '_context.People'  is null.");
            }
            _context.People.Add(record);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPerson", new { id = Person.ID }, Person);
            return CreatedAtAction(nameof(GetPerson), new { id = record.Id }, record);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(long id)
        {
            if (_context.People == null)
            {
                return NotFound();
            }
            var record = await _context.People.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.People.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(long id)
        {
            return (_context.People?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
