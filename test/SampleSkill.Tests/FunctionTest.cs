using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Xunit;

namespace SampleSkill.Tests;

public class FunctionTest
{
    [Fact]
    public void ShouldTellNotIntentTypeWhenRequestIsNotIntentType()
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
        Assert.Equal(Messages.NOT_INTENT_TYPE_MESSAGE, plainTextOutputSpeechResult.Text);
    }

    [Fact]
    public void ShouldTellCantUnderstandWhenIntentNameIsNotSampleSkillAndNotBuiltinAmazonNames()
    {
        // Act
        var request = new SkillRequest
        {
            Request = new IntentRequest
            {
                Intent = new()
                {
                    Name = "UNDEFINED"
                }
            }
        };

        // Arrange
        var result = Function.FunctionHandler(request);

        // Assert
        var plainTextOutputSpeechResult = Assert.IsType<PlainTextOutputSpeech>(result.Response.OutputSpeech);
        Assert.Equal(Messages.CANT_UNDERSTAND_MESSAGE, plainTextOutputSpeechResult.Text);
    }

    [Fact]
    public void ShouldTellByeMessageWhenIntentNameIsBuiltinAmazonStopIntent()
    {
        // Act
        var request = new SkillRequest
        {
            Request = new IntentRequest
            {
                Intent = new()
                {
                    Name = IntentNames.AMAZON_STOPINTENT
                }
            }
        };

        // Arrange
        var result = Function.FunctionHandler(request);

        // Assert
        var plainTextOutputSpeechResult = Assert.IsType<PlainTextOutputSpeech>(result.Response.OutputSpeech);
        Assert.Equal(Messages.BYE_MESSAGE, plainTextOutputSpeechResult.Text);
    }

    [Fact]
    public void ShouldTellByeMessageWhenIntentNameIsBuiltinAmazonCancelIntent()
    {
        // Act
        var request = new SkillRequest
        {
            Request = new IntentRequest
            {
                Intent = new()
                {
                    Name = IntentNames.AMAZON_CANCELINTENT
                }
            }
        };

        // Arrange
        var result = Function.FunctionHandler(request);

        // Assert
        var plainTextOutputSpeechResult = Assert.IsType<PlainTextOutputSpeech>(result.Response.OutputSpeech);
        Assert.Equal(Messages.BYE_MESSAGE, plainTextOutputSpeechResult.Text);
    }

    [Fact]
    public void ShouldTellHelpMessageWhenIntentNameIsBuiltinAmazonHelpIntent()
    {
        // Act
        var request = new SkillRequest
        {
            Request = new IntentRequest
            {
                Intent = new()
                {
                    Name = IntentNames.AMAZON_HELPINTENT
                }
            }
        };

        // Arrange
        var result = Function.FunctionHandler(request);

        // Assert
        var plainTextOutputSpeechResult = Assert.IsType<PlainTextOutputSpeech>(result.Response.OutputSpeech);
        Assert.Equal(Messages.HELP_MESSAGE, plainTextOutputSpeechResult.Text);
    }

    [Fact]
    public void ShouldTellSampleSkillMessageWhenIntentNameIsSampleSkill()
    {
        // Act
        var request = new SkillRequest
        {
            Request = new IntentRequest
            {
                Intent = new()
                {
                    Name = IntentNames.SAMPLE_SKILL
                }
            }
        };

        // Arrange
        var result = Function.FunctionHandler(request);

        // Assert
        var plainTextOutputSpeechResult = Assert.IsType<PlainTextOutputSpeech>(result.Response.OutputSpeech);
        Assert.Equal(Messages.SAMPLESKILL_MESSAGE, plainTextOutputSpeechResult.Text);
    }
}
