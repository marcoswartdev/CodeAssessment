namespace Receiver.UseCases;

public interface IReadMessageUseCase
{
    public void Execute(Action<string> callback);
}
