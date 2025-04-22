using FumbleFunds.Api.Repositories.Interfaces;

namespace FumbleFunds.Api.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Match>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Match?> GetUserByIdAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateUserAsync(Match match)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateUserAsync(Match match)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteUserAsync(int matchId)
        {
            throw new NotImplementedException();
        }
    }
}