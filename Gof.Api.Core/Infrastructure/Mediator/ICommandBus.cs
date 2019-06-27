using System.Threading;
using System.Threading.Tasks;

namespace Gof.Api.Core.Infrastructure
{
    public interface ICommandBus
    {
        Task<TResult> Send<TResult>(object command, CancellationToken cancellationToken);
    }
}
