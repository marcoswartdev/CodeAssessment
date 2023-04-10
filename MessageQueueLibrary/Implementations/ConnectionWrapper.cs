using MessageQueueLibrary.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace MessageQueueLibrary.Implementations;

public class ConnectionWrapper : IConnectionWrapper
{
    private readonly ConnectionFactory _factory;
    private readonly IConnection _connection;
    private bool _disposed;

    public ConnectionWrapper(string url)
    {
        try
        {
            _factory = new ConnectionFactory
            {
                Uri = new Uri(url)
            };
            _connection = _factory.CreateConnection();
        }
        catch (BrokerUnreachableException)
        {
            throw new Exception("Cound not connect to RabbitMQ. Please check the connection URL in app config.");
        }
    }

    public IConnection GetConnection()
    {
        return _connection;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
            _connection?.Close();

        _disposed = true;
    }
}
