using MessageQueueLibrary.Implementations;
using Sender.Repositories;
using Sender.UseCases;
using System.Configuration;

namespace Sender;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            string connectionURL = ConfigurationManager.AppSettings["ConnectionURL"]!;
            string queueName = ConfigurationManager.AppSettings["QueueName"]!;
            SendMessageUseCase sendMessageUseCase = new SendMessageUseCase(
                new SendMessageRepository(
                    new Producer(
                        new ConnectionWrapper(connectionURL), queueName)
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