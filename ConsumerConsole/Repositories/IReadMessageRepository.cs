namespace ConsumerConsole.Repositories;

public interface IReadMessageRepository
{
    void ReadMessage(Action<string> callback);
}
