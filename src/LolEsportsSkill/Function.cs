using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LolEsportsSkill;

public class Function
{
    private readonly ILolEsportsService _lolEsportsService;

    public Function() : this(new LolEsportsService())
    {
    }

    public Function(ILolEsportsService lolEsportsService)
    {
        _lolEsportsService = lolEsportsService;
    }

    public async Task<SkillResponse> FunctionHandlerAsync(SkillRequest request/*, ILambdaContext context*/)
    {
        return request.Request switch
        {
            LaunchRequest => await LaunchRequestHandlerAsync(),
            _ => ResponseBuilder.Empty(),
        };
    }

    private async Task<SkillResponse> LaunchRequestHandlerAsync()
    {
        var response = await _lolEsportsService.GetScheduleAsync();

        var events = response.Events;

        var nextGame = events
                            .Where(x => x.StartTime.Date >= DateTime.Now.Date)
                            .OrderBy(x => x.StartTime)
                            .FirstOrDefault();

        if (nextGame == null)
        {
            return ResponseBuilder.Tell(TextFormatter.NoGamesScheduled());
        }

        var teams = nextGame.Match.Teams;

        return nextGame.StartTime.Date == DateTime.Now.Date
            ? ResponseBuilder.Tell(TextFormatter.FormatGameDay(teams[0].Name, teams[1].Name, nextGame.StartTime))
            : ResponseBuilder.Tell(TextFormatter.TodayHasNoGame(teams[0].Name, teams[1].Name, nextGame.StartTime));
    }
}
