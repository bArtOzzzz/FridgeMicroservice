using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureServiceBusFunctions
{
    public class FunctionsWithAzureBus
    {
        [FunctionName("ReadMessageFromQueue")]
        public static void Run([ServiceBusTrigger("az-queue")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
