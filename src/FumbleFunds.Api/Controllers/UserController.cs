using FumbleFunds.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace FumbleFunds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null.");
            }

            var result = await _userService.UpdateUserAsync(user);
            if (!result)
            {
                return NotFound();
            }
            return Ok("User updated successfully.");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            if (!result)
            {
                return NotFound();
            }
            return Ok("User deleted successfully.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAsync([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null.");
            }

            var result = await _userService.CreateUserAsync(user);
            if (!result)
            {
                return BadRequest("Failed to create user.");
            }
            return CreatedAtAction(nameof(GetUserByIdAsync), new { userId = user.Id }, user);
        }
    }
}