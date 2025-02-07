using Assembly.Projecto.Final.ConsoleApp.UserInterface;
using Assembly.Projecto.Final.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

var connectionString = configuration.GetConnectionString("ProjectoFinalCS");
Console.WriteLine("Connection String: " + connectionString);

// Verificar outras configurações
var appName = configuration["AppSettings:ApplicationName"];
Console.WriteLine("Application Name: " + appName);

services.AddServices(configuration);

services.AddSingleton<Start>();

using var serviceProvider = services.BuildServiceProvider();

var start = serviceProvider.GetRequiredService<Start>();

start.Run();