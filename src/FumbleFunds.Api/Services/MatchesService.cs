using fumble_funds.Models.Entity.DTO;
using FumbleFunds.Api.Repositories.Interfaces;
using FumbleFunds.Api.Services.Interfaces;

namespace FumbleFunds.Api.Services
{

    public class MatchesService : IMatchesService
    {
        private readonly IMatchesRepository _matchesRepository;
        private readonly IExternalMatchService _external;

        public MatchesService(IMatchesRepository matchesRepository, IExternalMatchService external)
        {
            _matchesRepository = matchesRepository;
            _external = external;
        }
        public async Task<IEnumerable<ReturnedMatchDTO>> GetAllMatchesAsync()
        {
            var live = await _external.FetchAllAsync();
            foreach (var m in live)
            {
                var existing = await _matchesRepository.GetMatchByIdAsync(m.Id);
                if (existing == null)
                    await _matchesRepository.CreateMatchAsync(m);
                else
                    await _matchesRepository.UpdateMatchAsync(m);
            }
            var matches= await _matchesRepository.GetAllMatchesAsync();
            var dtos = new List<ReturnedMatchDTO>();
            foreach (var match in matches)
            {
                var dto = new ReturnedMatchDTO
                {
                    Id = match.Id,
                    HomeTeam = match.HomeTeam,
                    AwayTeam = match.AwayTeam,
                    StartTime = match.StartTime,
                    HomeScore = match.HomeScore,
                    AwayScore = match.AwayScore,
                    Status = match.Status
                };
                dtos.Add(dto);
            }

            return dtos;
        }
        public async Task<Match?> GetMatchByIdAsync(int matchId)
        {
            var local = await _matchesRepository.GetMatchByIdAsync(matchId);
            if (local != null) return local;

            var live = await _external.FetchByIdAsync(matchId);
            if (live == null) return null;

            await _matchesRepository.CreateMatchAsync(live);
            return live;
        }

        public async Task<IEnumerable<ReturnedMatchDTO>> GetPopularMatchesAsync(int count)
        {

            var matches = await _matchesRepository.GetPopularMatchesAsync(count);
            var dtos = new List<ReturnedMatchDTO>();
            foreach (var match in matches)
            {
                var dto = new ReturnedMatchDTO
                {
                    Id = match.Id,
                    HomeTeam = match.HomeTeam,
                    AwayTeam = match.AwayTeam,
                    StartTime = match.StartTime,
                    HomeScore = match.HomeScore,
                    AwayScore = match.AwayScore,
                    Status = match.Status
                };
                dtos.Add(dto);
            }

            return dtos;
        }

        public Task<Match> CreateMatchAsync(Match match)
        {
            return _matchesRepository.CreateMatchAsync(match);
        }
        public Task<bool> UpdateMatchAsync(Match match)
        {
            return _matchesRepository.UpdateMatchAsync(match);
        }
        public Task<bool> DeleteMatchAsync(int matchId)
        {
            return _matchesRepository.DeleteMatchAsync(matchId);
        }
    }
}