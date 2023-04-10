using Sender.UseCases;

namespace Sender;

public class App
{
    private readonly ISendMessageUseCase _sendMessageUseCase;

    public App(ISendMessageUseCase sendMessageUseCase)
    {
        _sendMessageUseCase = sendMessageUseCase;
    }

    public void Run(string[] args)
    {
        string name;
        Console.WriteLine("Please enter your name: ");
        name = Console.ReadLine() ?? "";
        _sendMessageUseCase.Execute(name);
    }
}
