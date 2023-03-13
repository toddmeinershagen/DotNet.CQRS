using System.Collections.Generic;
using MediatR;

namespace DotNet.CQRS
{
    public interface IQuery<out T> : IRequest<IEnumerable<T>>
    { }
}