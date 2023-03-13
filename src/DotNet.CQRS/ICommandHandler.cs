using MediatR;

namespace DotNet.CQRS
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand, IRequest
    { }
}