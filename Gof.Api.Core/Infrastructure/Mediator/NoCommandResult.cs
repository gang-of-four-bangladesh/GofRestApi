namespace Gof.Api.Core.Infrastructure
{
    public sealed class NoCommandResult
    {
        private readonly static NoCommandResult Singleton = new NoCommandResult();

        public NoCommandResult() { }

        public static NoCommandResult Instance
        {
            get
            {
                return Singleton;
            }
        }
    }
}