
using fumble_funds.Models.Entity.DTO;
using FumbleFunds.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FumbleFunds.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BetsController : ControllerBase
    {
        private readonly IBetService _betService;
        public BetsController(IBetService betService) => _betService = betService;

        // GET api/bets
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int userId)
        {
            var bets = await _betService.GetAllBetsByUserIdAsync(userId);
            if (bets == null || !bets.Any())
                return NotFound($"No bets found for user {userId}.");
            return Ok(bets);
        }

        // GET api/bets/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var bet = await _betService.GetBetByIdAsync(id);
            return bet is null
                ? NotFound()
                : Ok(bet);
        }

        // POST api/bets
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBetDto dto)
        {
            if(dto.MatchId == null || dto.UserId == null)
                return BadRequest("Match ID or User ID is required.");
            
            var bet = new Bet
            {
                UserId = dto.UserId,
                MatchId = dto.MatchId,
                Amount = dto.Amount,
                PredictedOutcome = dto.PredictedOutcome,
                PlacedAt = DateTime.UtcNow
            };

            var created = await _betService.CreateBetAsync(bet);
            return Ok(created);
        }

        // PUT api/bets/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Bet bet)
        {
            if (bet == null || bet.Id != id)
                return BadRequest("ID mismatch or missing payload.");

            var updated = await _betService.UpdateBetAsync(bet);
            return updated
                ? Ok(bet)
                : NotFound();
        }

        // DELETE api/bets/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _betService.DeleteBetAsync(id);
            return deleted
                ? NoContent()
                : NotFound();
        }
    }
}