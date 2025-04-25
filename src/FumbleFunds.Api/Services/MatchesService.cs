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
        public async Task<IEnumerable<Match>> GetAllMatchesAsync()
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
            return await _matchesRepository.GetAllMatchesAsync();
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