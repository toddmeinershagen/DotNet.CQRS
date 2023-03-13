using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;
using DotNet.CQRS.Azure.Data.Tables;
using DotNet.CQRS.Sample.Core;
using DotNet.CQRS.Sample.Core.Commands;

namespace DotNet.CQRS.Sample.Infrastructure.Azure.Data.Tables.Commands
{
    public class AddSettingsForEmployeeHandler : CommandHandler<AddSettingsForEmployee>
    {
        public AddSettingsForEmployeeHandler(IDataContextFactory<TableServiceClient> contextFactory) : base(contextFactory)
        {
        }

        protected override async Task Handle(TableServiceClient client, AddSettingsForEmployee command, CancellationToken cancellationToken)
        {
            var entity = new Entity<Settings>()
            {
                PartitionKey = command.Settings.ClientId.ToString(),
                RowKey = command.Settings.EmployeeUid.ToString(),
                Value = command.Settings
            };

            var tableClient = await client.GetTableClientAsync("settings", cancellationToken);
            var response = await tableClient.UpsertEntityAsync(entity, TableUpdateMode.Replace, default);
        }
    }
}