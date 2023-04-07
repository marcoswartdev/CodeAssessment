using RabbitMQ.Client;

namespace MessageQueueLibrary.Interfaces;
public interface IConnectionWrapper : IDisposable
{
    IConnection GetConnection();
}
