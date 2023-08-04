using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWorkWhisperAPI.Models;

namespace WorkWhisperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadsController : ControllerBase
    {
        private readonly NewWorkWhisperContext _context;

        public SquadsController(NewWorkWhisperContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("LastSquad")]
        public async Task<ActionResult<int>> LastSquad()
        {
            if (_context.Squads == null)
            {
                return NotFound();
            }
            Squad lastSquad = await _context.Squads.OrderBy(u => u.SquadId).LastOrDefaultAsync();

            if (lastSquad == null)
            {
                return NotFound();
            }

            return lastSquad.SquadId;
        }

        // GET: api/Squads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Squad>>> GetSquads()
        {
            if (_context.Squads == null)
            {
                return NotFound();
            }
            return await _context.Squads.ToListAsync();

        }
        [HttpGet]
        [Route("/getsquadbydesc")]
        public async Task<ActionResult<IEnumerable<Squad>>> GetSquadByDesc()
        {
            if (_context.Squads == null)
            {
                return NotFound();
            }

            // Modify the LINQ query to order the squads by CreatedAt in descending order
            var squads = await _context.Squads.OrderByDescending(s => s.CreatedAt).ToListAsync();

            return squads;
        }



        // GET: api/Squads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Squad>> GetSquad(int id)
        {
            if (_context.Squads == null)
            {
                return NotFound();
            }
            var squad = await _context.Squads.FindAsync(id);

            if (squad == null)
            {
                return NotFound();
            }

            return squad;
        }

        // PUT: api/Squads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSquad(int id, Squad squad)
        {
            if (id != squad.SquadId)
            {
                return BadRequest();
            }

            _context.Entry(squad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SquadExists(id))
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

        // POST: api/Squads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Squad>> PostSquad(Squad squad)
        {
            if (_context.Squads == null)
            {
                return Problem("Entity set 'WorkWhisperContext.Squads'  is null.");
            }
            _context.Squads.Add(squad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SquadExists(squad.SquadId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSquad", new { id = squad.SquadId }, squad);
        }

        // DELETE: api/Squads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSquad(int id)
        {
            if (_context.Squads == null)
            {
                return NotFound();
            }
            var squad = await _context.Squads.FindAsync(id);
            if (squad == null)
            {
                return NotFound();
            }

            _context.Squads.Remove(squad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpGet("descending")]
        //public async Task<ActionResult<IEnumerable<Squad>>> GetSquadsDescending()
        //{
        //    // Fetch all squads and sort them based on the CreatedAt column in descending order
        //    var squads = await _context.Squads.OrderByDescending(s => s.CreatedAt).ToListAsync();
        //    return squads;
        //}

        private bool SquadExists(int id)
        {
            return (_context.Squads?.Any(e => e.SquadId == id)).GetValueOrDefault();
        }
    }
}
