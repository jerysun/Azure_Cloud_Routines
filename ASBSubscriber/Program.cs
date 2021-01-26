using ASBShared.Models;
using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ASBSubscriber
{
    class Program
    {
        const string connectionString = "YOUR_OWN_SERVICE_BUS_CONNECTION_STRING";
        const string queueName = "personqueue";
        static IQueueClient queueClient;

        static async Task Main(string[] args)
        {
            try
            {
                queueClient = new QueueClient(connectionString, queueName);

                var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
                {
                    MaxConcurrentCalls = 1, // up to the number of CPUs and its cores
                    AutoComplete = false // won't mark the message as complete, we'll wait till it's read. According to the
                                         // default, we have the 30 seconds and the locker timer comes in, it will be unlocked
                                         // after 30 seconds, after that it's allowed to get pulled down by somebody else.
                };

                queueClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);

                Console.ReadLine(); //prevent the app from being immediately closed
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } finally
            {
                await queueClient.CloseAsync();
            }
        }

        private static async Task ProcessMessageAsync(Message message, CancellationToken token)
        {
            var jsonString = Encoding.UTF8.GetString(message.Body);
            PersonModel person = JsonSerializer.Deserialize<PersonModel>(jsonString);
            Console.WriteLine($"Person Received: {person.FirstName} {person.LastName}");

            // we passed the default 30-second locker token, the message will be removed from
            // the queue. Remember that we set the AutoCompete false
            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"Message handler exception: {arg.Exception}");
            return Task.CompletedTask;
        }
    }
}
