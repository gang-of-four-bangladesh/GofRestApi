using System;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace Gof.Api.Core.Infrastructure
{
    public class CommandBus : ICommandBus
    {
        private readonly Type GenericCommandHandler = typeof(ICommandHandler<,>);
        private readonly Func<Type, object> _resolver;
        private readonly ILogger _logger;
        public CommandBus(Func<Type, object> resolver, ILogger logger)
        {
            this._resolver = resolver;
            this._logger = logger;
        }
        
        public async Task<TResult> Send<TResult>(object command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            this._logger.Information("CommanBus processing {commandType} command.", command.GetType().Name);
            cancellationToken.ThrowIfCancellationRequested();

            var handlerType = GenericCommandHandler.MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = this._resolver(handlerType);
            var handlerName = ((Type)handler.GetType()).FullName;
            handler.Handle((dynamic)command);

            if (handler == null)
            {
                throw new InvalidOperationException($"Unable to find handler for the {command.GetType()} command.");
            }

            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                dynamic result = await handler.Handle((dynamic)command);
                var disposable = handler as IDisposable;
                disposable?.Dispose();
                return result;
            }
            catch (Exception exception)
            {
                this._logger.Error("Commandbus- Handler {handlerName} generates error.{errorDetails}", handlerName, exception);
                throw;
            }
        }
    }
}
