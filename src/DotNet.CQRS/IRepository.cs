using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotNet.CQRS
{
    public interface IRepository
    {
        Task<IEnumerable<T>> QueryAsync<T>(IQuery<T> query, CancellationToken cancellationToken);
        Task<T> QueryAsync<T>(IScalar<T> query, CancellationToken cancellationToken);
        Task ExecuteAsync(ICommand command, CancellationToken cancellationToken);
    }
}