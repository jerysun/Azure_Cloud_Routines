using System.Threading.Tasks;

namespace ASBPublisher.Services
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T serviceBusMessage, string queueName);
    }
}