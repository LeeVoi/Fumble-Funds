using FumbleFunds.Api.Repositories.Interfaces;
using FumbleFunds.Api.Services.Interfaces;

namespace FumbleFunds.Api.Services
{

    public class MatchesService : IMatchesService
    {
        private readonly IMatchesRepository _matchesRepository;

        public MatchesService(IMatchesRepository matchesRepository)
        {
            _matchesRepository = matchesRepository;
        }
        public Task<IEnumerable<Match>> GetAllMatchesAsync()
        {
            return _matchesRepository.GetAllMatchesAsync();
        }
        public Task<Match?> GetMatchByIdAsync(int matchId)
        {
            return _matchesRepository.GetMatchByIdAsync(matchId);
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