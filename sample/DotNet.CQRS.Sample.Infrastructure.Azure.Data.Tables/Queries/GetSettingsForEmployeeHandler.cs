using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;
using DotNet.CQRS.Azure.Data.Tables;
using DotNet.CQRS.Sample.Core;
using DotNet.CQRS.Sample.Core.Queries;
using Newtonsoft.Json;

namespace DotNet.CQRS.Sample.Infrastructure.Azure.Data.Tables.Queries
{
    public class GetSettingsForEmployeeHandler : ScalarHandler<GetSettingsForEmployee, Settings>
    {
        public GetSettingsForEmployeeHandler(IDataContextFactory<TableServiceClient> contextFactory)
            : base(contextFactory)
        { }

        protected override async Task<Settings> Handle(TableServiceClient client, GetSettingsForEmployee query, CancellationToken cancellationToken)
        {
            var tableClient = await client.GetTableClientAsync("settings", cancellationToken);

            var response = tableClient.Query<Entity<Settings>>(x => x.PartitionKey == query.ClientId.ToString() && x.RowKey == query.EmployeeUid.ToString());
            var entity = response.FirstOrDefault();

            if (entity == null) return null;

            var settings = JsonConvert.DeserializeObject<Settings>(entity.Json);

            return settings;
        }
    }
}