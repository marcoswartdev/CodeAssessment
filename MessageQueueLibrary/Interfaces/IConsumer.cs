namespace MessageQueueLibrary.Interfaces;

public interface IConsumer : IDisposable
{
    void ReadMessage(Action<string> callback);
}
