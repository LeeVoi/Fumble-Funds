using System.ComponentModel.DataAnnotations.Schema;
using fumble_funds.Models.Enums;
public class Bet
    {
        public int Id { get; set; }

        // foreign keys
        [ForeignKey(nameof(User))]
        public int UserId  { get; set; }
        public User User  { get; set; } = null!;

        [ForeignKey(nameof(Match))]
        public int MatchId { get; set; }
        public Match Match { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount           { get; set; }

        public Outcome PredictedOutcome { get; set; }

        public DateTime PlacedAt       { get; set; }
    }