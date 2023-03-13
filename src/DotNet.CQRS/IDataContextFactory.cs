using System.Threading.Tasks;

namespace DotNet.CQRS
{
    public interface IDataContextFactory<T>
    {
        Task<T> CreateAsync();
    }
}