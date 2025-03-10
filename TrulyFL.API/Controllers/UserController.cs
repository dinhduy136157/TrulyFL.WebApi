using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrulyFL.Application.Dtos.UserDto;
using TrulyFL.Application.Services.Interfaces;
using TrulyFL.Domain.Entity;

namespace TrulyFL.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            return Ok(new { Message = "Token Received", Token = authHeader });
        }
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            var user = await _userService.GetAllUserAsync();
            var userDto = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(userDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserByIdAsync(Guid Id)
        {
            var user = await _userService.GetByIdAsync(Id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.AddUserAsync(user);
            return Ok(userDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, UserDto userDto)
        {
            if (id != userDto.Id)
                return BadRequest();

            var user = _mapper.Map<User>(userDto);
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
