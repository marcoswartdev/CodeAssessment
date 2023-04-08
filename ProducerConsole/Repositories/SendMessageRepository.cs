using MessageQueueLibrary.Interfaces;

namespace Sender.Repositories;

public class SendMessageRepository : ISendMessageRepository
{
    private readonly IProducer _producer;

    public SendMessageRepository(IProducer producer)
    {
        _producer = producer;
    }

    public void SendMessage(string message)
    {
        _producer.SendMessage(message);
    }
}
