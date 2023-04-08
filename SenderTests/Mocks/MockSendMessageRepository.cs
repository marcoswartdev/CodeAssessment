using Sender.Repositories;

namespace SenderTests.Mocks;

public class MockSendMessageRepository : ISendMessageRepository
{
    public void SendMessage(string message) { }
}
