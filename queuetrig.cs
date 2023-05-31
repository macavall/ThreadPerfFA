using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace httpBlobFA
{
    public class queuetrig
    {
        private readonly ILogger _logger;

        public queuetrig(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<queuetrig>();
        }

        [Function("queuetrig")]
        public void Run([QueueTrigger("outputqueue", Connection = "queueconnstring")] string myQueueItem)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
