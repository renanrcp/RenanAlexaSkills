using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using LolEsportsSkill.Models;
using Moq;
using Xunit;

namespace LolEsportsSkill.UnitTests;

public class FunctionTest
{
    [Fact]
    public Task ShouldReturnTodayHasGameMessageWhenRequestTypeIsLaunchRequestAndTodayHasGame()
    {
        // Act
        var lolEsportsServiceMock = new Mock<ILolEsportsService>();

        _ = lolEsportsServiceMock.Setup(x => x.GetScheduleAsync(It.IsAny<string>()))
            .ReturnsAsync(new Schedule
            {
                Events = new()
                {
                    new()
                    {
                        StartTime = DateTime.Now
                    }
                }
            });

        var lolEsportsService = lolEsportsServiceMock.Object;
        return Task.CompletedTask;
    }
}
