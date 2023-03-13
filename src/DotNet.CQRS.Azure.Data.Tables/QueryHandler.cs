using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;

namespace DotNet.CQRS.Azure.Data.Tables
{
    public abstract class QueryHandler<TQuery, T> : IQueryHandler<TQuery, T> where TQuery : IQuery<T>
    {
        private readonly IDataContextFactory<TableServiceClient> _contextFactory;

        protected QueryHandler(IDataContextFactory<TableServiceClient> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<T>> Handle(TQuery query, CancellationToken cancellationToken)
        {
            var client = await _contextFactory.CreateAsync();

            //todo:  introduce retries or set it on the table service client.
            return await Handle(client, query, cancellationToken);
        }

        protected abstract Task<IEnumerable<T>> Handle(TableServiceClient client, TQuery query, CancellationToken cancellationToken);
    }
}