namespace FumbleFunds.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int userId);
        Task<bool> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
    }
}