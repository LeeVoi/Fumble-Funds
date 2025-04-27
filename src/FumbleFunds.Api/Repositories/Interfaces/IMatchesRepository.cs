namespace FumbleFunds.Api.Repositories.Interfaces
{

    public interface IMatchesRepository
    {
        Task<IEnumerable<Match>> GetAllMatchesAsync();
        Task<Match?> GetMatchByIdAsync(int matchId);
        Task<IEnumerable<Match>> GetPopularMatchesAsync(int count);
        Task<Match> CreateMatchAsync(Match match);
        Task<bool> UpdateMatchAsync(Match match);
        Task<bool> DeleteMatchAsync(int matchId);
    }
}