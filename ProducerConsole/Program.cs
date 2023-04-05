﻿using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client;
using System.Text;

namespace ProducerConsole
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
                string name = "";
                Console.WriteLine("To close the program type exit");
                do
                {
                    Console.WriteLine("Please enter your name: ");
                    name = Console.ReadLine() ?? "";
                    var body = Encoding.UTF8.GetBytes($"Hello my name is, {name}");
                    channel.BasicPublish("", "send-name-queue", null, body);
                } while (name.ToLower() != "exit");

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