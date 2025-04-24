namespace FumbleFunds.Api.Services.Interfaces
{

    public interface IMatchesService
    {
        Task<IEnumerable<Match>> GetAllMatchesAsync();
        Task<Match?> GetMatchByIdAsync(int matchId);
        Task<Match> CreateMatchAsync(Match match);
        Task<bool> UpdateMatchAsync(Match match);
        Task<bool> DeleteMatchAsync(int matchId);
    }
}