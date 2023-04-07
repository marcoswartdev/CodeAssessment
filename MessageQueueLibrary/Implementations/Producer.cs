using MessageQueueLibrary.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace MessageQueueLibrary.Implementations;

public class Producer : IProducer
{
    private readonly IConnectionWrapper _connectionWrapper;
    private readonly string _queue;
    private readonly IModel _model;
    private bool _disposed;

    public Producer(IConnectionWrapper connectionWrapper, string queue)
    {
        _connectionWrapper = connectionWrapper;
        _queue = queue;
        _model = _connectionWrapper.GetConnection().CreateModel();
        _model.QueueDeclare(
            _queue,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );
    }

    public void SendMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        _model.BasicPublish("", _queue, null, body);
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
            _model?.Close();

        _disposed = true;
    }
}
