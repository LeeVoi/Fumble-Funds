namespace FumbleFunds.Api.Services.Interfaces
{

    public interface IUserService
    {
        Task<IEnumerable<Match>> GetAllUsersAsync();
        Task<Match?> GetUserByIdAsync(int matchId);
        Task<bool> CreateUserAsync(Match match);
        Task<bool> UpdateUserAsync(Match match);
        Task<bool> DeleteUserAsync(int matchId);
    }
}