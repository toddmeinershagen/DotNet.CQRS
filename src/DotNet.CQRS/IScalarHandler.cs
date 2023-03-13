using MediatR;

namespace DotNet.CQRS
{
    public interface IScalarHandler<in TScalar, T> : IRequestHandler<TScalar, T> where TScalar : IScalar<T>, IRequest<T>
    { }
}