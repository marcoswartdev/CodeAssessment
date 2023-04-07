using ConsumerConsole.Repositories;
using ConsumerConsole.UseCases;
using MessageQueueLibrary.Implementations;

namespace ConsumerConsole;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            ReadMessageUseCase readMessageUseCase = new ReadMessageUseCase(
                new ReadMessageRepository(
                    new Consumer(
                        new ConnectionWrapper("amqp://guest:guest@localhost:5672"),
                        "send-name-queue"
                        )
                    )
                );
            readMessageUseCase.Execute((message) => Console.WriteLine(message));
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured - {e.Message}");
        }
    }
}