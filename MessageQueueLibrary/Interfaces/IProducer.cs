namespace MessageQueueLibrary.Interfaces;

public interface IProducer : IDisposable
{
    void SendMessage(string message);
}
