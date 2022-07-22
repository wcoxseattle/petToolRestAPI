using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetToolAPI.Models;

namespace FlagToolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlagTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FlagTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FlagTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlagType>>> GetFlagTypes()
        {
            if (_context.FlagTypes == null)
            {
                return NotFound();
            }
            return await _context.FlagTypes.ToListAsync();
        }

        // GET: api/FlagTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlagType>> GetFlagType(long id)
        {
            if (_context.FlagTypes == null)
            {
                return NotFound();
            }
            var record = await _context.FlagTypes.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // PUT: api/FlagTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlagType(long id, FlagType record)
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
                if (!FlagTypeExists(id))
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

        // POST: api/FlagTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlagType>> PostFlagType(FlagType record)
        {
            if (_context.FlagTypes == null)
            {
                return Problem("Entity set '_context.FlagTypes'  is null.");
            }
            _context.FlagTypes.Add(record);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetFlagType", new { id = FlagType.ID }, FlagType);
            return CreatedAtAction(nameof(GetFlagType), new { id = record.Id }, record);
        }

        // DELETE: api/FlagTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlagType(long id)
        {
            if (_context.FlagTypes == null)
            {
                return NotFound();
            }
            var record = await _context.FlagTypes.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.FlagTypes.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlagTypeExists(long id)
        {
            return (_context.FlagTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
