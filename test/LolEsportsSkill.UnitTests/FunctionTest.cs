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
    public async Task ShouldReturnTodayHasGameMessageWhenRequestTypeIsLaunchRequestAndTodayHasGame()
    {
        // Arrange
        var lolEsportsServiceMock = new Mock<ILolEsportsService>();

        _ = lolEsportsServiceMock.Setup(x => x.GetScheduleAsync(It.IsAny<string>()))
            .ReturnsAsync(new Schedule
            {
                Events = new()
                {
                    new()
                    {
                        StartTime = DateTime.Now,
                        Match = new()
                        {
                            Teams = new()
                            {
                                new()
                                {
                                    Name = "Team A",
                                },
                                new()
                                {
                                    Name = "Team B",
                                },
                            },
                        },
                    }
                }
            });

        var lolEsportsService = lolEsportsServiceMock.Object;

        var function = new Function(lolEsportsService);

        var request = new SkillRequest
        {
            Request = new LaunchRequest(),
        };

        // Act
        var response = await function.FunctionHandlerAsync(request);

        // Assert
        var plainTextOutputSpeechResult = Assert.IsType<PlainTextOutputSpeech>(response.Response.OutputSpeech);
        Assert.Equal(TextFormatter.FormatGameDay("Team A", "Team B", DateTime.Now), plainTextOutputSpeechResult.Text);
    }

    [Fact]
    public async Task ShouldReturnTodayHasNoGameMessageWhenRequestTypeIsLaunchRequestAndTodayHasNoGame()
    {
        // Arrange
        var lolEsportsServiceMock = new Mock<ILolEsportsService>();

        _ = lolEsportsServiceMock.Setup(x => x.GetScheduleAsync(It.IsAny<string>()))
            .ReturnsAsync(new Schedule
            {
                Events = new()
                {
                    new()
                    {
                        StartTime = DateTime.Now.AddDays(1),
                        Match = new()
                        {
                            Teams = new()
                            {
                                new()
                                {
                                    Name = "Team A",
                                },
                                new()
                                {
                                    Name = "Team B",
                                },
                            },
                        },
                    }
                }
            });

        var lolEsportsService = lolEsportsServiceMock.Object;

        var function = new Function(lolEsportsService);

        var request = new SkillRequest
        {
            Request = new LaunchRequest(),
        };

        // Act
        var response = await function.FunctionHandlerAsync(request);

        // Assert
        var plainTextOutputSpeechResult = Assert.IsType<PlainTextOutputSpeech>(response.Response.OutputSpeech);
        Assert.Equal(TextFormatter.TodayHasNoGame("Team A", "Team B", DateTime.Now.AddDays(1)), plainTextOutputSpeechResult.Text);
    }

    [Fact]
    public async Task ShouldReturnNoGamesScheduledMessageWhenRequestTypeIsLaunchRequestAndTodayHasNoGame()
    {
        // Arrange
        var lolEsportsServiceMock = new Mock<ILolEsportsService>();

        _ = lolEsportsServiceMock.Setup(x => x.GetScheduleAsync(It.IsAny<string>()))
            .ReturnsAsync(new Schedule
            {
                Events = new()
                {
                }
            });

        var lolEsportsService = lolEsportsServiceMock.Object;

        var function = new Function(lolEsportsService);

        var request = new SkillRequest
        {
            Request = new LaunchRequest(),
        };

        // Act
        var response = await function.FunctionHandlerAsync(request);

        // Assert
        var plainTextOutputSpeechResult = Assert.IsType<PlainTextOutputSpeech>(response.Response.OutputSpeech);
        Assert.Equal(TextFormatter.NoGamesScheduled(), plainTextOutputSpeechResult.Text);
    }

    [Fact]
    public async Task ShouldReturnEmptyResponseWhenRequestTypeIsNotRecognized()
    {
        // Arrange
        var lolEsportsServiceMock = new Mock<ILolEsportsService>();

        var lolEsportsService = lolEsportsServiceMock.Object;

        var function = new Function(lolEsportsService);

        var request = new SkillRequest
        {
            Request = new SkillEventRequest(),
        };

        // Act
        var response = await function.FunctionHandlerAsync(request);

        // Assert
        Assert.True(response.Response.ShouldEndSession);
        Assert.Null(response.Response.OutputSpeech);
    }
}
