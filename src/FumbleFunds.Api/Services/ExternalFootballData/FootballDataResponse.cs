using System.Text.Json.Serialization;

namespace FumbleFunds.Api.Services.ExternalFootballData
{
    public class FootballDataResponse
    {
        [JsonPropertyName("matches")]
        public List<ApiMatch> Matches { get; set; } = new();
    }

    public class ApiMatch
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("utcDate")]
        public DateTime UtcDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = "";

        [JsonPropertyName("homeTeam")]
        public ApiTeam HomeTeam { get; set; } = default!;

        [JsonPropertyName("awayTeam")]
        public ApiTeam AwayTeam { get; set; } = default!;

        [JsonPropertyName("score")]
        public ApiScore Score { get; set; } = default!;
    }

    public class ApiTeam
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
    }

    public class ApiScore
    {
        [JsonPropertyName("fullTime")]
        public ScorePeriod FullTime { get; set; } = default!;
    }

    public class ScorePeriod
    {
        [JsonPropertyName("home")]
        public int? Home { get; set; }

        [JsonPropertyName("away")]
        public int? Away { get; set; }
    }
}