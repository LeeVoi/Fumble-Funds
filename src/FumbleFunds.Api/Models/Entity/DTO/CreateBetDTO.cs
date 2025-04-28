namespace fumble_funds.Models.Entity.DTO;

using fumble_funds.Models.Enums;

public class CreateBetDto
{
    public int UserId { get; set; }
    public int MatchId { get; set; }
    public decimal Amount { get; set; }
    public Outcome PredictedOutcome { get; set; }
}