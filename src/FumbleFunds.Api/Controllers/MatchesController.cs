using FumbleFunds.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FumbleFunds.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchesService _matchService;
        private readonly IFeatureService _featureService;
        public MatchesController(IMatchesService matchService, IFeatureService featureService)
        {
            _matchService = matchService;
            _featureService = featureService;
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

        [HttpGet("popular/{count:int}")]
        public async Task<IActionResult> GetPopularAsync(int count = 10)
        {
            var enabled = await _featureService.GetFeatureFlagAsync("popular-matches");
            if (!enabled)
                return NotFound("Feature not enabled.");

            if (count <= 0)
                return BadRequest("Count must be greater than zero.");

            var matches = await _matchService.GetPopularMatchesAsync(count);
            if (matches == null || !matches.Any())
                return NotFound("No popular matches found.");

            return Ok(matches);
        }

        [HttpPost("create")]
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