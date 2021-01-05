using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pericia.ConsoleApp.Starter;
using System.IO;


var builder = new HostBuilder()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .ConfigureHostConfiguration(builder=> {
        builder.AddCommandLine(args);
    })
    .ConfigureAppConfiguration((ctx, builder) =>
    {
        builder.AddJsonFile("appsettings.json")
               .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true);

        if (ctx.HostingEnvironment.IsDevelopment())
        {
            builder.AddUserSecrets<App>();
        }
    })
    .ConfigureLogging((ctx, logging) =>
    {
        logging.AddConsole();
    })
    .ConfigureServices((ctx, services) =>
    {
        services.AddTransient<App>();
    })
    .UseConsoleLifetime();

var host = builder.Build();

using (var servicesScope = host.Services.CreateScope())
{
    var app = servicesScope.ServiceProvider.GetRequiredService<App>();
    await app.Run();
}