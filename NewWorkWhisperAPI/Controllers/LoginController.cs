
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWorkWhisperAPI.Models;

namespace NewWorkWhisperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly NewWorkWhisperContext _context;

        public LoginController(NewWorkWhisperContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<User>> Login(UserDTO userInput)
        {
            var DBUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userInput.Username);
            if (DBUser == null)
            {
                return BadRequest("User not found!!!");
            }
            else
            {
                if (userInput.Password != DBUser.Password)
                {
                    return BadRequest("Invalid Username or Password!!!");
                }
            }
            return Ok(DBUser);
        }
    }
}


