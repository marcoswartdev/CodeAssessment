using MessageQueueLibrary.Implementations;
using ProducerConsole.Repositories;
using ProducerConsole.UseCases;

namespace ProducerConsole;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            SendMessageUseCase sendMessageUseCase = new SendMessageUseCase(
                new SendMessageRepository(
                    new Producer(
                        new ConnectionWrapper("amqp://guest:guest@localhost:5672"),
                        "send-name-queue"
                        )
                    )
                );
            string name;
            while (true)
            {
                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine() ?? "";
                sendMessageUseCase.Execute(name);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured - {e.Message}");
        }
    }
}