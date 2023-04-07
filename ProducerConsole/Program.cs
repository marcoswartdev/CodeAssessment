using MessageQueueLibrary.Implementations;

namespace ProducerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConnectionWrapper connection = new ConnectionWrapper("amqp://guest:guest@localhost:5672");
                Producer producer = new Producer(connection,"send-name-queue");
                string name = "";
                Console.WriteLine("To close the program type exit");
                do
                {
                    Console.WriteLine("Please enter your name: ");
                    name = Console.ReadLine() ?? "";
                    var message = $"Hello my name is, {name}";
                    producer.SendMessage(message);
                } while (name.ToLower() != "exit");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured - {e.Message}");
            }
        }
    }
}