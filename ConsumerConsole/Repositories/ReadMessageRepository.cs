using MessageQueueLibrary.Interfaces;

namespace ConsumerConsole.Repositories;

public class ReadMessageRepository : IReadMessageRepository
{
    private readonly IConsumer _consumer;

    public ReadMessageRepository(IConsumer consumer)
    {
        _consumer = consumer;
    }

    public void ReadMessage(Action<string> callback)
    {
        _consumer.ReadMessage(callback);
    }
}
