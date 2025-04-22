using FumbleFunds.Api.Repositories.Interfaces;

namespace FumbleFunds.Api.Repositories
{

    public class BetRepository : IBetRepository
    {

        private readonly ApplicationDbContext _context;
        public BetRepository(ApplicationDbContext context)
        {
            _context = context;
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