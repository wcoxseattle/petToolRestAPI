using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetToolAPI.Models;

namespace PetToolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FoodsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Foods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
        {
            if (_context.Foods == null)
            {
                return NotFound();
            }

            return await _context.Foods.ToListAsync();
        }

        // GET: api/Foods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(long id)
        {
            if (_context.Foods == null)
            {
                return NotFound();
            }
            var record = await _context.Foods.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // PUT: api/Foods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(long id, Food record)
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
                if (!FoodExists(id))
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

        // POST: api/Foods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food record)
        {
            if (_context.Foods == null)
            {
                return Problem("Entity set '_context.Foods'  is null.");
            }
            _context.Foods.Add(record);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetFood", new { id = Food.ID }, Food);
            return CreatedAtAction(nameof(GetFood), new { id = record.Id }, record);
        }

        // DELETE: api/Foods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(long id)
        {
            if (_context.Foods == null)
            {
                return NotFound();
            }
            var record = await _context.Foods.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodExists(long id)
        {
            return (_context.Foods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
