using MessageQueueLibrary.Implementations;
using Sender.Repositories;
using Sender.UseCases;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MessageQueueLibrary.Interfaces;
using Sender;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

static IHostBuilder CreateHostBuilder(string[] args)
{
    var connectionURL = ConfigurationManager.AppSettings["ConnectionURL"]!;
    var queue = ConfigurationManager.AppSettings["QueueName"]!;
    return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
        {
            services.AddSingleton<IConnectionWrapper>(x => new ConnectionWrapper(connectionURL));
            services.AddSingleton<IProducer>(x => new Producer(x.GetRequiredService<IConnectionWrapper>(), queue));
            services.AddSingleton<ISendMessageRepository, SendMessageRepository>();
            services.AddSingleton<ISendMessageUseCase, SendMessageUseCase>();
            services.AddSingleton<App>();
        });
}

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine($"An error occured - {e.Message}");
}
