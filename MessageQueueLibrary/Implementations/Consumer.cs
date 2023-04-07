using MessageQueueLibrary.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessageQueueLibrary.Implementations;

public class Consumer : IConsumer
{
    private readonly IConnectionWrapper _connectionWrapper;
    private readonly string _queue;
    private readonly IModel _model;
    private bool _disposed;

    public Consumer(IConnectionWrapper connectionWrapper, string queue)
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

    public void ReadMessage(Action<string> callback)
    {
        var consumer = new EventingBasicConsumer(_model);
        consumer.Received += (sender, e) =>
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            callback(message);
        };
        _model.BasicConsume(_queue, true, consumer);
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
