using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;

namespace DotNet.CQRS.Azure.Data.Tables
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly IDataContextFactory<TableServiceClient> _contextFactory;

        protected CommandHandler(IDataContextFactory<TableServiceClient> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Handle(TCommand command, CancellationToken cancellationToken)
        {
            var client = await _contextFactory.CreateAsync();

            //todo:  introduce retries or set it on the table service client.
            await Handle(client, command, cancellationToken);
        }

        protected abstract Task Handle(TableServiceClient client, TCommand command, CancellationToken cancellationToken);
    }
}