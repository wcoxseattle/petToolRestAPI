using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetToolAPI.Models;

namespace PetToolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PetTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetType>>> GetPetTypes()
        {
            if (_context.PetTypes == null)
            {
                return NotFound();
            }
            return await _context.PetTypes.ToListAsync();
        }

        // GET: api/PetTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetType>> GetPetType(long id)
        {
            if (_context.PetTypes == null)
            {
                return NotFound();
            }
            var PetType = await _context.PetTypes.FindAsync(id);

            if (PetType == null)
            {
                return NotFound();
            }

            return PetType;
        }

        // PUT: api/PetTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetType(long id, PetType record)
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
                if (!PetTypeExists(id))
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

        // POST: api/PetTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PetType>> PostPetType(PetType record)
        {
            if (_context.PetTypes == null)
            {
                return Problem("Entity set '_context.PetTypes'  is null.");
            }
            _context.PetTypes.Add(record);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPetType", new { id = PetType.ID }, PetType);
            return CreatedAtAction(nameof(GetPetType), new { id = record.Id }, record);
        }

        // DELETE: api/PetTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetType(long id)
        {
            if (_context.PetTypes == null)
            {
                return NotFound();
            }
            var PetType = await _context.PetTypes.FindAsync(id);
            if (PetType == null)
            {
                return NotFound();
            }

            _context.PetTypes.Remove(PetType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetTypeExists(long id)
        {
            return (_context.PetTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
