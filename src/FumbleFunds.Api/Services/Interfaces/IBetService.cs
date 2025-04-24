namespace FumbleFunds.Api.Services.Interfaces
{
    public interface IBetService
    {
        Task<IEnumerable<Bet>> GetAllBetsByUserIdAsync(int userId);
        Task<Bet?> GetBetByIdAsync(int betId);
        Task<Bet> CreateBetAsync(Bet bet);
        Task<bool> UpdateBetAsync(Bet bet);
        Task<bool> DeleteBetAsync(int betId);
    }
}