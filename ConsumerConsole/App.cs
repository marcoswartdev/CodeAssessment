using Receiver.UseCases;

namespace Receiver;

public class App
{
    private readonly IReadMessageUseCase _readMessageUseCase;

    public App(IReadMessageUseCase readMessageUseCase)
    {
        _readMessageUseCase = readMessageUseCase;
    }

    public void Run(string[] args)
    {
        _readMessageUseCase.Execute((message) => Console.WriteLine(message));
        Console.ReadLine();
    }
}
