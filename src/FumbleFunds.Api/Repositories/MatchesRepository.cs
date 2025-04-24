using Microsoft.EntityFrameworkCore;
using FumbleFunds.Api.Repositories.Interfaces;

namespace FumbleFunds.Api.Repositories
{

    public class MatchesRepository : IMatchesRepository
    {

        private readonly ApplicationDbContext _context;
        public MatchesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetAllMatchesAsync()
        {
            return await _context.Matches
                     .Include(m => m.Bets)
                     .ToListAsync();
        }

        public async Task<Match?> GetMatchByIdAsync(int matchId)
        {
            return await _context.Matches
                     .Include(m => m.Bets)
                     .FirstOrDefaultAsync(m => m.Id == matchId);
        }
        public async Task<Match> CreateMatchAsync(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<bool> UpdateMatchAsync(Match match)
        {
            var existing = await _context.Matches.FindAsync(match.Id);
            if (existing == null) return false;

            existing.HomeTeam = match.HomeTeam;
            existing.AwayTeam = match.AwayTeam;
            existing.StartTime = match.StartTime;
            existing.HomeScore = match.HomeScore;
            existing.AwayScore = match.AwayScore;
            existing.Status = match.Status;

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteMatchAsync(int matchId)
        {
            var match = await _context.Matches.FindAsync(matchId);
            if (match == null) return false;

            _context.Matches.Remove(match);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}