using Assembly.Projecto.Final.ConsoleApp.UserInterface;
using Assembly.Projecto.Final.IoC;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddServices();

services.AddSingleton<Start>();

using var serviceProvider = services.BuildServiceProvider();

var start = serviceProvider.GetRequiredService<Start>();

start.Run();