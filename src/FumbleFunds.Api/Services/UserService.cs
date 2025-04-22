using FumbleFunds.Api.Repositories.Interfaces;
using FumbleFunds.Api.Services.Interfaces;

namespace FumbleFunds.Api.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<bool> CreateUserAsync(Match match)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Match>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Match?> GetUserByIdAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(Match match)
        {
            throw new NotImplementedException();
        }
    }
}