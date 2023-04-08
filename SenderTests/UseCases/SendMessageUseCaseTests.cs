
using Sender.UseCases;
using SenderTests.Mocks;

namespace SenderTests.UseCases
{
    public class SendMessageUseCaseTests
    {
        [Fact]
        public void ShouldSendMessage()
        {
            var mockRepository = new MockSendMessageRepository();
            var sendMessageUseCase = new SendMessageUseCase(mockRepository);

            sendMessageUseCase.Execute("test");

        }
    }
}
