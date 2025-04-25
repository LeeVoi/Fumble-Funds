using fumble_funds.Models.Enums;
using FumbleFunds.Api.Services.ExternalFootballData;
using FumbleFunds.Api.Services.Interfaces;

public class ExternalMatchesService : IExternalMatchService
{
    private readonly HttpClient _http;
    private readonly ILogger<ExternalMatchesService> _log;

    public ExternalMatchesService(HttpClient http, ILogger<ExternalMatchesService> log)
    {
        _http = http;
        _log = log;
    }
    public async Task<IEnumerable<Match>> FetchAllAsync()
    {
        try
        {
            var dto = await _http.GetFromJsonAsync<FootballDataResponse>("matches");
            return dto?.Matches.Select(ToDomain) ?? Array.Empty<Match>();
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "FetchAll failed");
            return Array.Empty<Match>();
        }
    }

    public async Task<Match?> FetchByIdAsync(int matchId)
    {
        try
        {
            var dto = await _http.GetFromJsonAsync<FootballDataResponse>($"matches/{matchId}");
            var api = dto?.Matches.FirstOrDefault();
            return api is null ? null : ToDomain(api);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "FetchById {MatchId} failed", matchId);
            return null;
        }
    }

    private static Match ToDomain(ApiMatch m) => new()
    {
        Id = m.Id,
        HomeTeam = m.HomeTeam.Name,
        AwayTeam = m.AwayTeam.Name,
        StartTime = m.UtcDate,
        HomeScore = m.Score.FullTime.Home,
        AwayScore = m.Score.FullTime.Away,
        Status = Enum.TryParse<MatchStatus>(m.Status, true, out var s) ? s : MatchStatus.Scheduled
    };
    private static MatchStatus MapStatus(string apiStatus)
    {
        return apiStatus.ToUpperInvariant() switch
        {
            "SCHEDULED" => MatchStatus.Scheduled,
            "TIMED" => MatchStatus.Scheduled,   // treat “timed” as scheduled
            "IN_PLAY" => MatchStatus.Live,
            "PAUSED" => MatchStatus.Live,        // paused is still “live”
            "FINISHED" => MatchStatus.Finished,
            _ => MatchStatus.Scheduled    // default fallback
        };
    }
}

