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
    public class ToysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Toys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toy>>> GetToys()
        {
            if (_context.Toys == null)
            {
                return NotFound();
            }

            return await _context.Toys.ToListAsync();
        }

        // GET: api/Toys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toy>> GetToy(long id)
        {
            if (_context.Toys == null)
            {
                return NotFound();
            }
            var record = await _context.Toys.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // PUT: api/Toys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToy(long id, Toy record)
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
                if (!ToyExists(id))
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

        // POST: api/Toys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Toy>> PostToy(Toy record)
        {
            if (_context.Toys == null)
            {
                return Problem("Entity set '_context.Toys'  is null.");
            }
            _context.Toys.Add(record);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetToy", new { id = Toy.ID }, Toy);
            return CreatedAtAction(nameof(GetToy), new { id = record.Id }, record);
        }

        // DELETE: api/Toys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToy(long id)
        {
            if (_context.Toys == null)
            {
                return NotFound();
            }
            var record = await _context.Toys.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Toys.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToyExists(long id)
        {
            return (_context.Toys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
