using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Xunit;

namespace SampleSkill.Tests;

public class FunctionTest
{
    [Fact]
    public void ShouldReturnEmptyResponseWhenRequestIsNotLaunchType()
    {
        // Act
        var request = new SkillRequest
        {
            Request = new IntentRequest()
        };

        // Arrange
        var result = Function.FunctionHandler(request);

        // Assert
        Assert.True(result.Response.ShouldEndSession);
        Assert.Null(result.Response.OutputSpeech);
    }

    [Fact]
    public void ShouldTellSampleSkillMesageWhenRequestIsLaunchType()
    {
        // Act
        var request = new SkillRequest
        {
            Request = new LaunchRequest()
        };

        // Arrange
        var result = Function.FunctionHandler(request);

        // Assert
        var plainTextOutputSpeechResult = Assert.IsType<PlainTextOutputSpeech>(result.Response.OutputSpeech);
        Assert.Equal(Messages.SAMPLESKILL_MESSAGE, plainTextOutputSpeechResult.Text);
    }
}
