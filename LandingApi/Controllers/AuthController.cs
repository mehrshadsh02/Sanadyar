using Microsoft.AspNetCore.Mvc;

namespace LandingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            if (dto.Username == "admin" && dto.Password == "1234")
            {
                return Ok(new { success = true, message = "ورود موفقیت‌آمیز بود." });
            }

            return Unauthorized(new { success = false, message = "نام کاربری یا رمز عبور اشتباه است." });
        }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
 