using System.Net.Http.Json;
using LolEsportsSkill.Models;

namespace LolEsportsSkill;

public class LolEsportsService : ILolEsportsService
{
    private readonly HttpClient _httpClient;

    private const string DEFAULT_HL = "pt-BR";
    private const string DEFAULT_LEAGUE_ID = "98767991332355509";
    private const string DEFAULT_API_KEY = "0TvQnueqKa5mxJntVWt0w4LpLfEkrV1Ta8rQBb9Z";

    public LolEsportsService() : this(CreateDefaultHttpClient())
    {
    }

    public LolEsportsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    internal static HttpClient CreateDefaultHttpClient()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://esports-api.lolesports.com/persisted/gw/")
        };

        // Shared API Key for every request
        httpClient.DefaultRequestHeaders.Add("x-api-key", DEFAULT_API_KEY);

        return httpClient;
    }

    public async Task<Schedule> GetScheduleAsync(string? pageToken)
    {
        var requestUri = $"getSchedule?hl={DEFAULT_HL}&leagueId={DEFAULT_LEAGUE_ID}";

        if (!string.IsNullOrWhiteSpace(pageToken))
        {
            requestUri += $"&pageToken={pageToken}";
        }

        var response = await _httpClient.GetFromJsonAsync<LolEsportsResponse>(requestUri);

        return response!.Data.Schedule;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _httpClient.Dispose();
    }
}
