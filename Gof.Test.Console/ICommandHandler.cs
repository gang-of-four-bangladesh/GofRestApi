using System;
using System.Threading.Tasks;

namespace Gof.Test.Console
{
    public interface ICommandHandler<in TCommand,TResult>
    {
        TResult Handle(TCommand command);
    }
}
