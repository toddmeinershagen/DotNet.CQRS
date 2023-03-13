using System.Threading.Tasks;
using Azure.Data.Tables;

namespace DotNet.CQRS.Azure.Data.Tables
{
    public class TableServiceClientFactory : IDataContextFactory<TableServiceClient>
    {
        private readonly string _connectionString;

        public TableServiceClientFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<TableServiceClient> CreateAsync()
        {
            var client = new TableServiceClient(_connectionString);
            return Task.FromResult(client);
        }
    }
}