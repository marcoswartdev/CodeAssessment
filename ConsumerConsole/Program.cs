using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client;
using System.Text.RegularExpressions;
using System.Text;

namespace ConsumerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri("amqp://guest:guest@localhost:5672")
                };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.QueueDeclare(
                    "send-name-queue",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender, args) =>
                {
                    var body = args.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var name = message.Substring(message.LastIndexOf(',') + 1).Trim();
                    Regex namePattern = new Regex(@"^[a-zA-Z]+(?:[\s]+[a-zA-Z]+)*$");
                    bool isNameValid = namePattern.IsMatch(name);
                    if (isNameValid)
                    {
                        Console.WriteLine($"Hello {name}, I am your father!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not a valid name");
                    }
                };

                channel.BasicConsume("send-name-queue", true, consumer);
                Console.ReadLine();
            }
            catch (BrokerUnreachableException)
            {
                Console.WriteLine("Could not connect to rabbitMQ. Please make sure the docker container is running and using the correct ports");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured - {e}");
            }
        }
    }
}