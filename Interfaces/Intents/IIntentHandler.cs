﻿using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Alexa.NET.Request;
using Alexa.NET.Response;

namespace ASMRDarling.API.Interfaces
{
    public interface IIntentHandler
    {
        Task<SkillResponse> HandleIntent(Intent input, Session session, ILambdaLogger logger);
    }
}