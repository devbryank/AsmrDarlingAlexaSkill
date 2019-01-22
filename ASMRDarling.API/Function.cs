using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ASMRDarling.API
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>

        private static HttpClient _httpClient;
        public const string INVOCATION_NAME = "ASMR Darling";


        public Function()
        {
            _httpClient = new HttpClient();
        }


        public async Task<SkillResponse> FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var requestType = input.GetRequestType();

            if (requestType == typeof(IntentRequest))
            {
                var intentRequest = input.Request as IntentRequest;
                var fileRequested = intentRequest?.Intent?.Slots["file"].Value;

                if (fileRequested == null)
                {
                    context.Logger.LogLine($"The file {fileRequested} was not avaliable."); // null value anyways
                    return MakeSkillResponse($"Sorry Bryan. {INVOCATION_NAME} did not work.", false);
                }

                return MakeSkillResponse($"You have selected {fileRequested}", true);
            }
            else
            {
                return MakeSkillResponse("You have failed me", true);
            }
        }


        private SkillResponse MakeSkillResponse(string outputSpeech, bool shouldEndSession, string repromptText = "Hello world.")
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech }
            };

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };

            return skillResponse;
        }
    }
}
