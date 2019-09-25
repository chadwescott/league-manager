using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using LeagueManager.Api.Configs;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LeagueManager.Api.Middleware
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly string _headerId;

        public CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger, CorrelationIdSettings settings)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger;
            _headerId = settings.HeaderId;
        }

        public async Task Invoke(HttpContext context)
        {
            var header = context.Request.Headers[_headerId];
            var correlationId = header.Count == 0 ? Guid.NewGuid().ToString() : header[0];
            context.Items[_headerId] = correlationId;

            var items = context.Items.Values;
            var dictionary = new Dictionary<string, string> { { _headerId, correlationId.ToString() } };
            using (_logger.BeginScope(dictionary))
                await _next(context);
        }
    }
}
