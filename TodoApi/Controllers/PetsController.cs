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
    public class PetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            if (_context.Pets == null)
            {
                return NotFound();
            }

            return await _context.Pets.ToListAsync();
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(long id)
        {
            if (_context.Pets == null)
            {
                return NotFound();
            }
            var record = await _context.Pets.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // PUT: api/Pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(long id, Pet record)
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
                if (!PetExists(id))
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

        // POST: api/Pets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet record)
        {
            if (_context.Pets == null)
            {
                return Problem("Entity set '_context.Pets'  is null.");
            }
            _context.Pets.Add(record);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPet", new { id = Pet.ID }, Pet);
            return CreatedAtAction(nameof(GetPet), new { id = record.Id }, record);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(long id)
        {
            if (_context.Pets == null)
            {
                return NotFound();
            }
            var record = await _context.Pets.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetExists(long id)
        {
            return (_context.Pets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
