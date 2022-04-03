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
        return input.Request is LaunchRequest
            ? ResponseBuilder.Tell(Messages.SAMPLESKILL_MESSAGE)
            : ResponseBuilder.Empty();
    }
}
