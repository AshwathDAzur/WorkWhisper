
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWorkWhisperAPI.Models;
using WorkWhisperAPI.BusinessLogics;

namespace WorkWhisperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSquadController : ControllerBase
    {
        private readonly NewWorkWhisperContext _context;

        public UserSquadController(NewWorkWhisperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetuserSquad()
        {
            var result = (
                from user in _context.Users
                join usersquad in _context.UserSquads on user.UserId equals usersquad.UserUserId
                join squad in _context.Squads on usersquad.SquadSquadId equals squad.SquadId
                select new
                {
                    username = user.UserName,
                    squadname = squad.Title
                }
            ).ToList();
            return result;
        }

    }
}
