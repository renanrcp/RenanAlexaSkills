using Xunit;

namespace LolEsportsSkill.Tests;

public class LolEsportsServiceTest : IClassFixture<LolEsportsServiceFixture>
{
    private readonly LolEsportsServiceFixture _lolEsportsServiceFixture;

    public LolEsportsServiceTest(LolEsportsServiceFixture lolEsportsServiceFixture)
    {
        _lolEsportsServiceFixture = lolEsportsServiceFixture;
    }

    [Fact]
    public async Task GetScheduleAsyncReturnsSchedule()
    {
        var lolEsportsService = _lolEsportsServiceFixture.LolEsportsService;

        var schedule = await lolEsportsService.GetScheduleAsync(null);

        Assert.NotNull(schedule);
        Assert.NotEmpty(schedule.Events);
    }
}

public class LolEsportsServiceFixture : IDisposable
{
    public LolEsportsService LolEsportsService { get; }

    public LolEsportsServiceFixture()
    {
        LolEsportsService = new();
    }

    public void Dispose()
    {
        LolEsportsService.Dispose();
        GC.SuppressFinalize(this);
    }
}
