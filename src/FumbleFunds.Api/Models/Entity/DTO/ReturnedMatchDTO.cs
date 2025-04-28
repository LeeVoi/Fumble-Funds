using fumble_funds.Models.Enums;

namespace fumble_funds.Models.Entity.DTO;

public class ReturnedMatchDTO
{
    public int Id { get; set; }

    public string HomeTeam  { get; set; } = string.Empty;

    public string AwayTeam  { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }

    public MatchStatus Status { get; set; } = MatchStatus.Scheduled;

}