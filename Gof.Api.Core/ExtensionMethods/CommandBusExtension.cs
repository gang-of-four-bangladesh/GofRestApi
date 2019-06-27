using System;
using System.Threading;
using System.Threading.Tasks;
using Gof.Api.Core.Infrastructure;

namespace Gof.Api.Core.ExtensionMethods
{
    public static class CommandBusExtension
    {
        public static Task<TResult> Send<TResult>(this ICommandBus instance, object command)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(ICommandBus));
            }

            return instance.Send<TResult>(command, CancellationToken.None);
        }

        public static Task Send(this ICommandBus instance, object command)
        {
            return instance.Send<NoCommandResult>(command);
        }
    }
}

// rehan
// toufika    rahaman
// jahirul islam

// apple


// orange
// water melon
// pa