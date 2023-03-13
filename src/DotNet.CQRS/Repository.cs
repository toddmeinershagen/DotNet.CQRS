using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DotNet.CQRS
{
    public class Repository : IRepository
    {
        private readonly IMediator _mediator;

        public Repository(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IEnumerable<T>> QueryAsync<T>(IQuery<T> query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken);
        }

        public async Task<T> QueryAsync<T>(IScalar<T> query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken);
        }

        public async Task ExecuteAsync(ICommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
        }
    }
}