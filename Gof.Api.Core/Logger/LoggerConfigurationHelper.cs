using Microsoft.Extensions.Configuration;
using Serilog;

namespace Gof.Api.Core.Logger
{
    public static class LoggerConfigurationHelper
    {
        public static void ConfigureLogger(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}