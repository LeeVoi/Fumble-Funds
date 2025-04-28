using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Bet>> GetAllBetsByUserIdAsync(int userId)
        {
            return await _context.Bets
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public Task<Bet?> GetBetByIdAsync(int betId)
        {
            return _context.Bets
        .FirstOrDefaultAsync(b => b.Id == betId);
        }

        public async Task<Bet> CreateBetAsync(Bet bet)
        {
            _context.Bets.Add(bet);
            await _context.SaveChangesAsync();
            return bet;
        }
        public Task<bool> UpdateBetAsync(Bet bet)
        {
            var existing = _context.Bets.Find(bet.Id);
            if (existing == null)
                return Task.FromResult(false);

            existing.UserId = bet.UserId;
            existing.MatchId = bet.MatchId;
            existing.Amount = bet.Amount;
            existing.PredictedOutcome = bet.PredictedOutcome;
            existing.PlacedAt = bet.PlacedAt;

            var updated = _context.SaveChanges() > 0;
            return Task.FromResult(updated);
        }
        public Task<bool> DeleteBetAsync(int betId)
        {
            var bet = _context.Bets.Find(betId);
            if (bet == null)
                return Task.FromResult(false);

            _context.Bets.Remove(bet);
            var deleted = _context.SaveChanges() > 0;
            return Task.FromResult(deleted);
        }
    }
}