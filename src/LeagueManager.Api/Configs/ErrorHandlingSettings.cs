using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;

namespace LeagueManager.Api.Configs
{
    public class ErrorHandlingSettings
    {
        public Dictionary<Type, int> ExceptionStatusMap = new Dictionary<Type, int>
        {
            { typeof(ArgumentException), StatusCodes.Status400BadRequest },
            { typeof(ArgumentNullException), StatusCodes.Status400BadRequest },
        };
    }
}
