using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using LeagueManager.Api.Configs;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace LeagueManager.Api.Middleware
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly ApplicationDetails _applicationDetails;

        public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> logger, ApplicationDetails applicationDetails)
        {
            _next = next;
            _logger = logger;
            _applicationDetails = applicationDetails;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var originalRequestBody = context.Request.Body;
            var requestBodyStream = new MemoryStream();
            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var url = UriHelper.GetDisplayUrl(context.Request);
            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
            requestBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requestBodyStream;

            var originalResponseBody = context.Response.Body;
            var responseBodyStream = new MemoryStream();
            context.Response.Body = responseBodyStream;

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();

                var route = context.GetRouteData();
                var controller = route?.Values?.ContainsKey("controller") ?? false ? route.Values["controller"] : null;
                var action = route?.Values?.ContainsKey("action") ?? false ? route.Values["action"] : null;

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                var responseBody = new StreamReader(responseBodyStream).ReadToEnd();

                var operationId = $"{_applicationDetails.ApplicationName}:{controller}:{action}";

                _logger.LogInformation("Response: {OperationId}, {Method}, {ApplicationName}, {Environment}, {Version}, {Controller}, {Action}, {Url}, {Headers}, {RequestBody}, {StatusCode}, {ResponseBody}, {Duration}",
                    operationId,
                    context.Request.Method,
                    _applicationDetails.ApplicationName,
                    _applicationDetails.Environment,
                    _applicationDetails.Version,
                    controller,
                    action,
                    url,
                    context.Request.Headers,
                    requestBodyText,
                    context.Response.StatusCode,
                    responseBody,
                    stopwatch.ElapsedMilliseconds);

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                await responseBodyStream.CopyToAsync(originalResponseBody);
            }
        }

    }
}
