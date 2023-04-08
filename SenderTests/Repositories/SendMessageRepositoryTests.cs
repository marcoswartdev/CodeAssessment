using Sender.Repositories;
using SenderTests.Mocks;

namespace SenderTests.Repositories;

public class SendMessageRepositoryTests
{
    [Fact]
    public void ShouldSendMessage()
    {
        var mockProducer = new MockProducer();
        var sendMessageRepository = new SendMessageRepository(mockProducer);

        sendMessageRepository.SendMessage("test");

    }
}
