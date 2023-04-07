using MessageQueueLibrary.Implementations;
using System.Text.RegularExpressions;

namespace ConsumerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConnectionWrapper connection = new ConnectionWrapper("amqp://guest:guest@localhost:5672");
                Consumer consumer = new Consumer(connection, "send-name-queue");
                consumer.ReadMessage((message) =>
                {
                    var name = message.Substring(message.LastIndexOf(',') + 1).Trim();
                    Regex namePattern = new Regex(@"^[a-zA-Z]+(?:[\s]+[a-zA-Z]+)*$");
                    bool isNameValid = namePattern.IsMatch(name);
                    if (name.ToLower() == "exit")
                    {
                        //do nothing
                    }
                    else if (isNameValid)
                    {
                        Console.WriteLine($"Hello {name}, I am your father!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not a valid name");
                    }
                });
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured - {e.Message}");
            }
        }
    }
}