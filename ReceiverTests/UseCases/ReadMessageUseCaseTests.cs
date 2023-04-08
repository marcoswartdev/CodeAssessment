using Receiver.UseCases;
using ReceiverTests.Mocks;

namespace ReceiverTests.UseCases;

public class ReadMessageUseCaseTests
{
    [Fact]
    public void ShouldReturnMessage()
    {
        var expected = "Hello Test User, I am your father!";
        var mockRepository = new MockReadMessageRepository("Hello my name is, Test User");
        var readMessageUseCase = new ReadMessageUseCase(mockRepository);

        readMessageUseCase.Execute((message) =>
        {
            Assert.Equal(expected, message);
        });
    }

    [Fact]
    public void ShouldReturnInvalidMessage()
    {
        var expected = "Test1234 is not a valid name";
        var mockRepository = new MockReadMessageRepository("Hello my name is, Test1234");
        var readMessageUseCase = new ReadMessageUseCase(mockRepository);

        readMessageUseCase.Execute((message) =>
        {
            Assert.Equal(expected, message);
        });
    }
}
