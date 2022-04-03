using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SampleSkill;

public static class Function
{
    public static string FunctionHandler(string input, ILambdaContext context)
    {
        return input.ToUpper();
    }
}
