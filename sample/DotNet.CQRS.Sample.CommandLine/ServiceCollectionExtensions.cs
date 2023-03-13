using Azure.Data.Tables;
using DotNet.CQRS.Azure.Data.Tables;
using DotNet.CQRS.Sample.Core.Commands;
using DotNet.CQRS.Sample.Infrastructure.Azure.Data.Tables.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.CQRS.Sample.CommandLine;

public static class ServiceCollectionExtensions
{
    public static void Configure(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(Program).Assembly,
                typeof(Repository).Assembly,
                typeof(AddSettingsForEmployee).Assembly,
                typeof(AddSettingsForEmployeeHandler).Assembly);
        });

        var connectionString = Environment.GetEnvironmentVariable("AzureTableConnectionString");
        services.AddScoped<IDataContextFactory<TableServiceClient>>(
            _ => new TableServiceClientFactory(connectionString));
        services.AddScoped<IRepository, Repository>();
        services.AddScoped(_ => Console.Out);
        services.AddScoped<Function>();
    }
}