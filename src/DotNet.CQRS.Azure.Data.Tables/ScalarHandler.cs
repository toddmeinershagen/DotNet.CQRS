using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;

namespace DotNet.CQRS.Azure.Data.Tables
{
    public abstract class ScalarHandler<TScalar, T> : IScalarHandler<TScalar, T> where TScalar : IScalar<T>
    {
        private readonly IDataContextFactory<TableServiceClient> _contextFactory;

        protected ScalarHandler(IDataContextFactory<TableServiceClient> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Handle(TScalar query, CancellationToken cancellationToken)
        {
            var client = await _contextFactory.CreateAsync();

            //todo:  introduce retries or set it on the table service client.
            return await Handle(client, query, cancellationToken);
        }

        protected abstract Task<T> Handle(TableServiceClient client, TScalar query, CancellationToken cancellationToken);
    }
}