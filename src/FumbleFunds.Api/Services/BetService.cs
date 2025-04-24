using FumbleFunds.Api.Repositories.Interfaces;
using FumbleFunds.Api.Services.Interfaces;

namespace FumbleFunds.Api.Services
{

    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;

        public BetService(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }
        public Task<IEnumerable<Bet>> GetAllBetsByUserIdAsync(int userId)
        {
            return _betRepository.GetAllBetsByUserIdAsync(userId);
        }

        public Task<Bet?> GetBetByIdAsync(int betId)
        {
            return _betRepository.GetBetByIdAsync(betId);
        }

        public Task<Bet> CreateBetAsync(Bet bet)
        {
            return _betRepository.CreateBetAsync(bet);
        }
        public Task<bool> UpdateBetAsync(Bet bet)
        {
            return _betRepository.UpdateBetAsync(bet);
        }
        public Task<bool> DeleteBetAsync(int betId)
        {
            return _betRepository.DeleteBetAsync(betId);
        }
    }
}