using System.ComponentModel.DataAnnotations;
using fumble_funds.Models.Enums;
public class Match
    {
        public int Id { get; set; }

        [Required]
        public string HomeTeam  { get; set; } = string.Empty;

        [Required]
        public string AwayTeam  { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        // scores only set once Finished
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }

        public MatchStatus Status { get; set; } = MatchStatus.Scheduled;

        // nav
        public ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }