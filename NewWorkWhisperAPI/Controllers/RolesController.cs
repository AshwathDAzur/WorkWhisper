using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWorkWhisperAPI.Models;

namespace NewWorkWhisperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly NewWorkWhisperContext _context;

        public RoleController(NewWorkWhisperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetuserRole()
        {
            var result = (
                from user in _context.Users
                join roles in _context.Roles on user.RoleRoleId equals roles.RoleId

                select new
                {
                    userid = user.UserId,
                    role = roles.Role1,
                    username = user.UserName
                }
            ).ToList();
            return result;
        }
    }
}

