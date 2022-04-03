using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SampleSkill;

public static class Function
{
    public static SkillResponse FunctionHandler(SkillRequest input/*, ILambdaContext context*/)
    {
        return input.Request is not IntentRequest intentRequest
            ? ResponseBuilder.Tell(Messages.NOT_INTENT_TYPE_MESSAGE)
            : intentRequest.Intent.Name.ToUpper() switch
            {
                IntentNames.AMAZON_CANCELINTENT => ResponseBuilder.Tell(Messages.BYE_MESSAGE),
                IntentNames.AMAZON_STOPINTENT => ResponseBuilder.Tell(Messages.BYE_MESSAGE),
                IntentNames.AMAZON_HELPINTENT => ResponseBuilder.Tell(Messages.HELP_MESSAGE),
                IntentNames.SAMPLE_SKILL => ResponseBuilder.Tell(Messages.SAMPLESKILL_MESSAGE),
                _ => ResponseBuilder.Tell(Messages.CANT_UNDERSTAND_MESSAGE)
            };
    }
}
