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
        // Act
        var lolEsportsService = _lolEsportsServiceFixture.LolEsportsService;

        // Arrange
        var schedule = await lolEsportsService.GetScheduleAsync(null);

        // Assert
        Assert.NotNull(schedule);
        Assert.NotEmpty(schedule.Events);
    }

    [Fact]
    public async Task GetScheduleAsyncReturnsMoreOlderSchedulesWithPage()
    {
        // Act
        var lolEsportsService = _lolEsportsServiceFixture.LolEsportsService;

        // Arrange
        var firstSchedule = await lolEsportsService.GetScheduleAsync(null);

        // This can occurs if doesnt has previous games in the tournament.
        if (string.IsNullOrWhiteSpace(firstSchedule.Pages.Older))
        {
            return;
        }

        var secondSchedule = await lolEsportsService.GetScheduleAsync(firstSchedule.Pages.Older);

        // Assert
        Assert.NotNull(secondSchedule);
        Assert.NotEmpty(secondSchedule.Events);
        Assert.NotEqual(firstSchedule.Events, secondSchedule.Events);
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
