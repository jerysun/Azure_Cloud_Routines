using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace AZSBTopicSubscription
{
    class Program
    {
        static string connectionString = "YOUR_CONNECTION_STRING";

        static string topicName = "aznewtopic";
        static string subscriptionName = "mysubscription";

        static async Task Main(string[] args)
        {
            await SendMessageToTopicAsync();
            await SendMessagesToTopicAsync();
            await ReceiveMessagesFromSubscriptionAsync();
        }

        static async Task SendMessageToTopicAsync()
        {
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                ServiceBusSender sender = client.CreateSender(topicName);
                await sender.SendMessageAsync(new ServiceBusMessage("The first msg to topic!"));
                Console.WriteLine($"Send a single message to the topic: {topicName}");
            }
        }

        static Queue<ServiceBusMessage> CreateMessages()
        {
            Queue<ServiceBusMessage> messages = new Queue<ServiceBusMessage>();
            messages.Enqueue(new ServiceBusMessage("First Message"));
            messages.Enqueue(new ServiceBusMessage("Second Message"));
            messages.Enqueue(new ServiceBusMessage("Third Message"));
            return messages;
        }

        static async Task SendMessagesToTopicAsync()
        {
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                ServiceBusSender sender = client.CreateSender(topicName);
                Queue<ServiceBusMessage> messages = CreateMessages();
                int messageCount = messages.Count;

                while (messages.Count > 0)
                {
                    using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

                    // add the message at the region of the queue to the batch
                    if (messageBatch.TryAddMessage(messages.Peek()))
                    {
                        messages.Dequeue();
                    } else
                    {
                        //if the beginning message can't fit, then it's too large for the batch
                        throw new Exception($"Message {messageCount - messages.Count} is too large and cannot be sent.");
                    }

                    while (messages.Count > 0 && messageBatch.TryAddMessage(messages.Peek()))
                    {
                        messages.Dequeue();
                    }

                    await sender.SendMessagesAsync(messageBatch);
                }

                Console.WriteLine($"Sent a batch of {messageCount} messages to the topic: {topicName}");
            }
        }

        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body} from subscription: {subscriptionName}");

            //complete the message. message is deleted from the queue.
            await args.CompleteMessageAsync(args.Message);
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        static async Task ReceiveMessagesFromSubscriptionAsync()
        {
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                ServiceBusProcessor processor = client.CreateProcessor(topicName, subscriptionName, new ServiceBusProcessorOptions());

                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                await processor.StartProcessingAsync();

                Console.WriteLine("Wait for a minute and then press any key to end the processing");
                Console.ReadKey();

                //Stop processing
                Console.WriteLine("\nStopping the receiver...");
                await processor.StopProcessingAsync();
                Console.WriteLine("Stopped receiving messages");
            }
        }
    }
}
