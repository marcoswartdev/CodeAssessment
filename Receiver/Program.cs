using Receiver.Repositories;
using MessageQueueLibrary.Implementations;
using Receiver.UseCases;
using System.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MessageQueueLibrary.Interfaces;
using Receiver;

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
        services.AddSingleton<IConsumer>(x => new Consumer(x.GetRequiredService<IConnectionWrapper>(), queue));
        services.AddSingleton<IReadMessageRepository, ReadMessageRepository>();
        services.AddSingleton<IReadMessageUseCase, ReadMessageUseCase>();
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
