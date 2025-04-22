using FumbleFunds.Api.Repositories.Interfaces;

namespace FumbleFunds.Api.Repositories
{

    public class MatchesRepository : IMatchesRepository
    {

        private readonly ApplicationDbContext _context;
        public MatchesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Match>> GetAllMatchesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Match?> GetMatchByIdAsync(int matchId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CreateMatchAsync(Match match)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMatchAsync(Match match)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteMatchAsync(int matchId)
        {
            throw new NotImplementedException();
        }

    }
}