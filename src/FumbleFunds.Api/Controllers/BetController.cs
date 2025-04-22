

using FumbleFunds.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FumbleFunds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;

        public BetController(IBetService betService)
        {
            _betService = betService;
        }
        
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllBetsByUserIdAsync(int userId)
        {
            var bets = await _betService.GetAllBetsByUserIdAsync(userId);
            return Ok(bets);
        }
        [HttpGet("{betId}")]
        public async Task<IActionResult> GetBetByIdAsync(int betId)
        {
            var bet = await _betService.GetBetByIdAsync(betId);
            if (bet == null)
            {
                return NotFound();
            }
            return Ok(bet);
        }
    }
}