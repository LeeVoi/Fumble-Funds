using FumbleFunds.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FumbleFunds.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchesService _matchService;
        public MatchesController(IMatchesService matchService)
        {
            _matchService = matchService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var matches = await _matchService.GetAllMatchesAsync();
            if (!matches.Any())
                return NotFound("No matches found.");
            return Ok(matches);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var match = await _matchService.GetMatchByIdAsync(id);
            return match is null
                ? NotFound()
                : Ok(match);
        }

                [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Match match)
        {
            if (match == null) 
                return BadRequest("Match payload is required.");

            var created = await _matchService.CreateMatchAsync(match);
            return Ok(created);
        }

                [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Match match)
        {
            if (match == null || match.Id != id)
                return BadRequest("ID mismatch or missing payload.");

            var updated = await _matchService.UpdateMatchAsync(match);
            return updated 
                ? Ok(match) 
                : NotFound();
        }

                [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _matchService.DeleteMatchAsync(id);
            return deleted 
                ? NoContent() 
                : NotFound();
        }
    }
}