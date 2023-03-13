// See https://aka.ms/new-console-template for more information

using DotNet.CQRS.Sample.CommandLine;
using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();
services.Configure();

var provider = services.BuildServiceProvider();
var function = provider.GetService<Function>();
await function.ExecuteAsync();

await Console.In.ReadLineAsync();