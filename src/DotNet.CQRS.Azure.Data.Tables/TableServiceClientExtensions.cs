using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;

namespace DotNet.CQRS.Azure.Data.Tables
{
    public static class TableServiceClientExtensions
    {
        public static async Task<TableClient> GetTableClientAsync(this TableServiceClient client, string tableName, CancellationToken cancellationToken)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            var tableClient = client.GetTableClient(tableName);
            await tableClient.CreateIfNotExistsAsync(cancellationToken);
            return tableClient;
        }
    }
}