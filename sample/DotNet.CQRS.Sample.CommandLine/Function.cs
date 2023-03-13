using DotNet.CQRS.Sample.Core;
using DotNet.CQRS.Sample.Core.Commands;
using DotNet.CQRS.Sample.Core.Queries;
using Newtonsoft.Json;

namespace DotNet.CQRS.Sample.CommandLine;

public class Function
{
    private readonly IRepository _repository;
    private readonly TextWriter _writer;

    public Function(IRepository repository, TextWriter writer)
    {
        _repository = repository;
        _writer = writer;
    }

    public async Task ExecuteAsync()
    {
        var clientId = 213476;
        var employeeUid = 132000811877576;

        var settings = new Settings
        {
            ClientId = clientId,
            EmployeeUid = employeeUid,
            Widgets = new[] { "widget2", "widget4" }.ToList()
        };

        await _repository.ExecuteAsync(new AddSettingsForEmployee(settings), default);
        await _writer.WriteLineAsync($"Upsert:  {JsonConvert.SerializeObject(settings)}");

        var retrieved = await _repository.QueryAsync(new GetSettingsForEmployee(clientId, employeeUid), default);
        await _writer.WriteLineAsync($"Read: {JsonConvert.SerializeObject(retrieved)}");
    }
}