using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWorkWhisperAPI.Models;

namespace NewWorkWhisperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhispersController : ControllerBase
    {
        private readonly NewWorkWhisperContext _context;

        public WhispersController(NewWorkWhisperContext context)
        {
            _context = context;
        }

        // get the whispers of all Squads

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> WhispersOfAllSquads()
        {
            var result = (
                from Whisper in _context.Whispers
                join squads in _context.Squads on Whisper.SquadSquadId equals squads.SquadId 
                join users in _context.Users on Whisper.UserUserId equals users.UserId
                join type in _context.WhisperTypes on Whisper.WhisperTypeWtypeId equals type.WtypeId
                join topic in _context.WhisperTopics on Whisper.WhisperTopicWtopicId equals topic.WtopicId
                select new
                {
                    whisperid = Whisper.WhispId,
                    SquadName = squads.Title,
                    SquadId = squads.SquadId,
                    Username = users.UserName,
                    UserId = users.UserId,
                    Whisper = Whisper.WhisperContent,
                    type = type.Type,
                    topic = topic.Topic
                }
            ).ToList();
            return result;
        }

        // get the whispers of one Squads
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<object>>> WhispersOfOneSquad(int id)
        {
            var result = (
                from Whisper in _context.Whispers
                join squads in _context.Squads on Whisper.SquadSquadId equals squads.SquadId
                join users in _context.Users on Whisper.UserUserId equals users.UserId
                join type in _context.WhisperTypes on Whisper.WhisperTypeWtypeId equals type.WtypeId
                join topic in _context.WhisperTopics on Whisper.WhisperTopicWtopicId equals topic.WtopicId
                where squads.SquadId == id
                select new
                {
                    whisperid = Whisper.WhispId,
                    SquadName = squads.Title,
                    SquadId = squads.SquadId,
                    Username = users.UserName,
                    UserId = users.UserId,
                    Whisper = Whisper.WhisperContent,
                    type = type.Type,
                    topic = topic.Topic

                }
            ).OrderByDescending(item => item.whisperid).ToList();

            return result;
        }


        // Add post to the Squad

        [HttpPost]
        public async Task<IActionResult> AddWhisper([FromBody] WhisperModel model)
        {
            try
            {
                var squad = await _context.Squads.FindAsync(model.SquadId);
                if (squad == null)
                {
                    return NotFound();
                }

                var user = await _context.Users.FindAsync(model.UserId);
                if (user == null)
                {
                    return NotFound();
                }

                var topic = await _context.WhisperTopics.FindAsync(model.WhisperTopicWtopicId);
                if (topic == null)
                {
                    return BadRequest();
                }
                var type = await _context.WhisperTypes.FindAsync(model.WhisperTypeWtypeId);
                if (type == null)
                {
                    return BadRequest();
                }

                var whisper = new Whisper
                {
                    WhispId = model.WhisperId,
                    WhisperContent = model.WhisperContent,
                    WhisperTopicWtopicId = model.WhisperTopicWtopicId,
                    WhisperTypeWtypeId = model.WhisperTypeWtypeId,
                    SquadSquadId = model.SquadId,
                    UserUserId = model.UserId,
                };

                _context.Whispers.Add(whisper);
                await _context.SaveChangesAsync();

                return Ok("Whisper added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding the whisper.");
            }
        }
    }
}
