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
    public class FeedBacksController : ControllerBase
    {
        private readonly NewWorkWhisperContext _context;

        public FeedBacksController(NewWorkWhisperContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("LastFeedback")]
        public async Task<ActionResult<int>> Lastfeedback()
        {
            if (_context.FeedBacks == null)
            {
                return NotFound();
            }

            FeedBack lastfeedback = await _context.FeedBacks.OrderBy(u => u.FeedBackId).LastOrDefaultAsync();

            if (lastfeedback == null)
            {
                return NotFound();
            }

            return lastfeedback.FeedBackId;
        }

        // GET: api/FeedBacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedBack>>> GetFeedBacks()
        {
          if (_context.FeedBacks == null)
          {
              return NotFound();
          }
            return await _context.FeedBacks.ToListAsync();
        }

        // GET: api/FeedBacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedBack>> GetFeedBack(int id)
        {
          if (_context.FeedBacks == null)
          {
              return NotFound();
          }
            var feedBack = await _context.FeedBacks.FindAsync(id);

            if (feedBack == null)
            {
                return NotFound();
            }

            return feedBack;
        }

        // PUT: api/FeedBacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedBack(int id, FeedBack feedBack)
        {
            if (id != feedBack.FeedBackId)
            {
                return BadRequest();
            }

            _context.Entry(feedBack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedBackExists(id))
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

        // POST: api/FeedBacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        public async Task<ActionResult<FeedBack>> PostFeedBack(FeedBack feedBack)
        {
          if (_context.FeedBacks == null)
          {
              return Problem("Entity set 'NewWorkWhisperContext.FeedBacks'  is null.");
          }
            _context.FeedBacks.Add(feedBack);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FeedBackExists(feedBack.FeedBackId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFeedBack", new { id = feedBack.FeedBackId }, feedBack);
        }

        // DELETE: api/FeedBacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedBack(int id)
        {
            if (_context.FeedBacks == null)
            {
                return NotFound();
            }
            var feedBack = await _context.FeedBacks.FindAsync(id);
            if (feedBack == null)
            {
                return NotFound();
            }

            _context.FeedBacks.Remove(feedBack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedBackExists(int id)
        {
            return (_context.FeedBacks?.Any(e => e.FeedBackId == id)).GetValueOrDefault();
        }
    }
}
