using MediatR;

namespace DotNet.CQRS
{
    public interface IScalar<out T> : IRequest<T>
    { }
}