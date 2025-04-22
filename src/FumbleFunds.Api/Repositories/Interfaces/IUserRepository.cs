namespace FumbleFunds.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Match>> GetAllUsersAsync();
        Task<Match?> GetUserByIdAsync(int matchId);
        Task<bool> CreateUserAsync(Match match);
        Task<bool> UpdateUserAsync(Match match);
        Task<bool> DeleteUserAsync(int matchId);
    }
}