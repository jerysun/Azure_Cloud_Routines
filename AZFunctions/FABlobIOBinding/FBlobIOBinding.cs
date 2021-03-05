using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FABlobInputBinding
{
    public static class FBlobIOBinding
    {
        [FunctionName("FBlobIO")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]string myQueueItem, 
            [Blob("dev/{queueTrigger}", FileAccess.Read, Connection = "AzureWebJobsStorage")] Stream myBlob,
            [Blob("dev/latestqueuemsg.txt", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream outBlob,
            ILogger log)
        {
            log.LogInformation($"BlobInput processed blob\n Name: {myQueueItem} \n Size: {myBlob.Length} bytes");

            StreamReader reader = new StreamReader(myBlob);
            log.LogInformation($"Content: {reader.ReadToEnd()}");

            StreamWriter writer = new StreamWriter(outBlob);
            outBlob.Write(Encoding.ASCII.GetBytes(myQueueItem));
        }
    }
}
