using System.Threading.Tasks;

namespace Gof.Api.Core.Infrastructure
{
    public interface ICommandHandler<in TCommand, TCommandResult>
    {
        Task<TCommandResult> Handle(TCommand command);
    }
}