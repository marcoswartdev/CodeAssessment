using Receiver.Repositories;
using MessageQueueLibrary.Implementations;
using Receiver.UseCases;
using System.Configuration;

namespace Receiver;

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
                        new ConnectionWrapper(connectionURL), queueName)
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