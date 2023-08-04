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
    public class LikesController : ControllerBase
    {
        private readonly NewWorkWhisperContext _context;

        public LikesController(NewWorkWhisperContext context)
        {
            _context = context;
        }


        // POST: api/Likes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Like>> PostLike(Like like)
        {
          if (_context.Likes == null)
          {
              return Problem("Entity set 'NewWorkWhisperContext.Likes'  is null.");
          }
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLike", new { id = like.LikeId }, like);
        }



        private bool LikeExists(int id)
        {
            return (_context.Likes?.Any(e => e.LikeId == id)).GetValueOrDefault();
        }
    }
}
