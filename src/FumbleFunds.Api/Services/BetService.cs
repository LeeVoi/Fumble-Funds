using FumbleFunds.Api.Repositories.Interfaces;
using FumbleFunds.Api.Services.Interfaces;

namespace FumbleFunds.Api.Services{

    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;

        public BetService(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }
        
        public Task<bool> CreateBetAsync(Bet bet)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBetAsync(int betId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bet>> GetAllBetsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Bet?> GetBetByIdAsync(int betId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBetAsync(Bet bet)
        {
            throw new NotImplementedException();
        }
    }
}