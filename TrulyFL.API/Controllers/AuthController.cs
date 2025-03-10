using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrulyFL.Application.Dtos.LoginDto;

namespace TrulyFL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto.UserName != "string" || loginDto.Password != "string")
            {
                return Unauthorized("Invalid Username or Password");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration["JwtSettings:Key"];
            if (string.IsNullOrEmpty(secret))
            {
                return BadRequest("JWT Secret Key is missing.");
            }

            var key = Encoding.UTF8.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, loginDto.UserName),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }
}
