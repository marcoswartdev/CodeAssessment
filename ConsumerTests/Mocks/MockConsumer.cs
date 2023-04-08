using MessageQueueLibrary.Interfaces;

namespace RecieverTests.Mocks;

public class MockConsumer : IConsumer
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void ReadMessage(Action<string> callback)
    {
        callback("Hello my name is, Test User");
    }
}
