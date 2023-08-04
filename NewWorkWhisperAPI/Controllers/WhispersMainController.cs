using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWorkWhisperAPI.Models;

namespace NewWorkWhisperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhispersMainController : ControllerBase
    {
        private readonly NewWorkWhisperContext _context;

        public WhispersMainController(NewWorkWhisperContext context)
        {
            _context = context;
        }

        // GET: api/WhispersMain
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Whisper>>> GetWhispers()
        {
          if (_context.Whispers == null)
          {
              return NotFound();
          }
            return await _context.Whispers.ToListAsync();
        }

        // GET: api/WhispersMain/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Whisper>> GetWhisper(int id)
        {
          if (_context.Whispers == null)
          {
              return NotFound();
          }
            var whisper = await _context.Whispers.FindAsync(id);

            if (whisper == null)
            {
                return NotFound();
            }

            return whisper;
        }

        // PUT: api/WhispersMain/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWhisper(int id, Whisper whisper)
        {
            if (id != whisper.WhispId)
            {
                return BadRequest();
            }

            _context.Entry(whisper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WhisperExists(id))
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

        // POST: api/WhispersMain
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Whisper>> PostWhisper(Whisper whisper)
        {
          if (_context.Whispers == null)
          {
              return Problem("Entity set 'NewWorkWhisperContext.Whispers'  is null.");
          }
            _context.Whispers.Add(whisper);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WhisperExists(whisper.WhispId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWhisper", new { id = whisper.WhispId }, whisper);
        }

        // DELETE: api/WhispersMain/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhisper(int id)
        {
            if (_context.Whispers == null)
            {
                return NotFound();
            }
            var whisper = await _context.Whispers.FindAsync(id);
            if (whisper == null)
            {
                return NotFound();
            }

            _context.Whispers.Remove(whisper);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WhisperExists(int id)
        {
            return (_context.Whispers?.Any(e => e.WhispId == id)).GetValueOrDefault();
        }
    }
}
