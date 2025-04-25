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

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return _userRepository.GetAllUsersAsync();
        }
        public Task<User?> GetUserByIdAsync(int userId)
        {
            return _userRepository.GetUserByIdAsync(userId);
        }

        public Task<User> CreateUserAsync(User user)
        {
            return _userRepository.CreateUserAsync(user);
        }
        public Task<bool> UpdateUserAsync(User user)
        {
            return _userRepository.UpdateUserAsync(user);
        }
        public Task<bool> DeleteUserAsync(int userId)
        {
            return _userRepository.DeleteUserAsync(userId);
        }
    }
}