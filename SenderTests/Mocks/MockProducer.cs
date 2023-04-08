
using MessageQueueLibrary.Interfaces;

namespace SenderTests.Mocks;

public class MockProducer : IProducer
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void SendMessage(string message) { }
}
