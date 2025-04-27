namespace FumbleFunds.Api.Services.Interfaces
{
    public interface IExternalMatchService
    {
        Task<IEnumerable<Match>> FetchAllAsync();
        Task<Match?> FetchByIdAsync(int matchId);
    }
}