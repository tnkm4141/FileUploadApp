using FileUploadApp.Dtos;
using FileUploadApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            var result = await _authService.Register(request);
            if (result == "Username already exists")
                return BadRequest(result);

            return Ok(new { token = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            var result = await _authService.Login(request);
            if (result == "User not found" || result == "Incorrect password")
                return BadRequest(result);

            return Ok(new { token = result });
        }
    }
}
