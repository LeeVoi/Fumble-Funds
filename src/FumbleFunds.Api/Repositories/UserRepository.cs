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

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return Task.FromResult(_context.Users.AsEnumerable());
        }
        public Task<User?> GetUserByIdAsync(int userId)
        {
            return _context.Users.FindAsync(userId).AsTask();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public Task<bool> UpdateUserAsync(User user)
        {
            var existingUser= _context.Users.Find(user.Id);
            if (existingUser == null)
            {
                return Task.FromResult(false);
            }
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            return Task.FromResult(_context.SaveChanges() > 0);
        }
        public Task<bool> DeleteUserAsync(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return Task.FromResult(false);
            }
            _context.Users.Remove(user);
            return Task.FromResult(_context.SaveChanges() > 0);
        }
    }
}