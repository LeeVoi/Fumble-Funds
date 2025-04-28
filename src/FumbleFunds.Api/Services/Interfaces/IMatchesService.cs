using fumble_funds.Models.Entity.DTO;

namespace FumbleFunds.Api.Services.Interfaces
{

    public interface IMatchesService
    {
        Task<IEnumerable<ReturnedMatchDTO>> GetAllMatchesAsync();
        Task<Match?> GetMatchByIdAsync(int matchId);
        Task<IEnumerable<ReturnedMatchDTO>> GetPopularMatchesAsync(int count);
        Task<Match> CreateMatchAsync(Match match);
        Task<bool> UpdateMatchAsync(Match match);
        Task<bool> DeleteMatchAsync(int matchId);
    }
}