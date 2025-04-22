using FumbleFunds.Api.Repositories.Interfaces;
using FumbleFunds.Api.Services.Interfaces;

namespace FumbleFunds.Api.Services{

    public class MatchesService : IMatchesService
    {
        private readonly IMatchesRepository _matchesRepository;

        public MatchesService(IMatchesRepository matchesRepository)
        {
            _matchesRepository = matchesRepository;
        }
        public Task<bool> CreateMatchAsync(Match match)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMatchAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Match>> GetAllMatchesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Match?> GetMatchByIdAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMatchAsync(Match match)
        {
            throw new NotImplementedException();
        }
    }
}