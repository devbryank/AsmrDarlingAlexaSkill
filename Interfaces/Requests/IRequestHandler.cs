﻿using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;

namespace ASMRDarling.API.Interfaces
{
    public interface IRequestHandler
    {
        Task<SkillResponse> HandleRequest(LaunchRequest request, ILambdaLogger logger);
        Task<SkillResponse> HandleRequest(IntentRequest request, Session session, ILambdaLogger logger);
        Task<SkillResponse> HandleRequest(AudioPlayerRequest request, ILambdaLogger logger);
    }
}
