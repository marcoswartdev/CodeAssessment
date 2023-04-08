using Receiver.Repositories;

namespace ReceiverTests.Mocks;

public class MockReadMessageRepository : IReadMessageRepository
{
    private readonly string _mockMessage;

    public MockReadMessageRepository(string mockMessage)
    {
        _mockMessage = mockMessage;
    }

    public void ReadMessage(Action<string> callback)
    {
        callback(_mockMessage);
    }
}

