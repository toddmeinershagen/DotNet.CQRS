using System.Collections.Generic;
using MediatR;

namespace DotNet.CQRS
{
    public interface IQueryHandler<in TQuery, T> : IRequestHandler<TQuery, IEnumerable<T>> where TQuery : IQuery<T>, IRequest<IEnumerable<T>>
    { }
}