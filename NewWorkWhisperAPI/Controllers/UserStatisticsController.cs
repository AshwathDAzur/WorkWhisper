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
    public class UserStatisticsController : ControllerBase
    {
        private readonly NewWorkWhisperContext _context;

        public UserStatisticsController(NewWorkWhisperContext context)
        {
            _context = context;
        }

        // squad vs Number of whsipers per squad
        [HttpGet("{userId}")]
        public async Task<ActionResult<Dictionary<string, int>>> NumofWhispersPerSquadForUser(int userId)
        {
            var result = await (
                from whisper in _context.Whispers
                where whisper.UserUserId == userId
                join squad in _context.Squads on whisper.SquadSquadId equals squad.SquadId
                group whisper by new { squad.SquadId, squad.Title } into g
                select new
                {
                    SquadId = g.Key.SquadId,
                    SquadName = g.Key.Title,
                    TotalWhisperCount = g.Count()
                }
            ).ToDictionaryAsync(x => x.SquadName, x => x.TotalWhisperCount);

            return result;
        }


        [HttpGet]
        public async Task<ActionResult<object>> GetLikes(int userUserId)
        {
            try
            {
                var likeCount = await _context.Likes
                    .Where(like => like.UserUserId == userUserId && like.Like1 == 1)
                    .CountAsync();

                var dislikeCount = await _context.Likes
                    .Where(dlike => dlike.UserUserId == userUserId && dlike.Like1 == 0)
                    .CountAsync();

                var result = new
                {
                    Likes = likeCount,
                    Dislikes = dislikeCount
                };

                return result;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.ToString());
                return NotFound();
            }
        }

    }
}
