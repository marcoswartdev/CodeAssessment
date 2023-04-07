using ConsumerConsole.Repositories;
using ConsumerConsole.UseCases;
using MessageQueueLibrary.Implementations;
using System.Configuration;

namespace ConsumerConsole;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            string connectionURL = ConfigurationManager.AppSettings["ConnectionURL"]!;
            string queueName = ConfigurationManager.AppSettings["QueueName"]!;
            ReadMessageUseCase readMessageUseCase = new ReadMessageUseCase(
                new ReadMessageRepository(
                    new Consumer(
                        new ConnectionWrapper(connectionURL),queueName)
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