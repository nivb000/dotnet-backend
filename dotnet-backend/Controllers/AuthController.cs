using dotnet_backend.Data;
using dotnet_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet_backend.Services;

namespace dotnet_backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IssueDbContext _context;
        private ITokenService _tokenService;
        public AuthController(IssueDbContext context, ITokenService token)  {
            _context = context;
            _tokenService = token;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var dbUser = _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if (dbUser == null)
            {
                return BadRequest("Email or password is incorrect");
            }
            var token = await _tokenService.GenerateToken(dbUser.Id.ToString());
            var cookieOptions = Utils.Cookie.CreateOptions(Request.Host.Host);
            Response.Cookies.Append("login-token", token, cookieOptions);
            return Ok(token);
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            var dbUser = _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
            if (dbUser != null)
            {
                return BadRequest("Email already taken");
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok("User signed up");
        }
    }
}
