using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace httpBlobFA
{
    public class httpfunc
    {
        private readonly ILogger _logger;

        public httpfunc(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<httpfunc>();
        }

        [Function("httpfunc")]
        [QueueOutput("outputqueue")]
        public string? Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // get req body
            string? body = req.ReadAsString();

            return (body != null) ? body : "Body is Null";
        }
    }
}
