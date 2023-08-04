using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWorkWhisperAPI.Models;
using WorkWhisperAPI.BusinessLogics;

namespace NewWorkWhisperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherController : ControllerBase
    {
        private readonly NewWorkWhisperContext _context;

        public OtherController(NewWorkWhisperContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("LastWhisper")]
        public async Task<ActionResult<int>> LastWhisper()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            Whisper lastWhisper = await _context.Whispers.OrderBy(u => u.WhispId).LastOrDefaultAsync();

            if (lastWhisper == null)
            {
                return NotFound();
            }

            return lastWhisper.WhispId;
        }


    }
}
