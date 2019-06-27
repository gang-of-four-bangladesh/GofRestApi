using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Gof.Api.Data
{
    public class DataContextFactory : IDataContextFactory
    {
        private readonly IConfiguration _configuration;

        public DataContextFactory(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        
        public Task<DataContext> Create()
        {
            throw new System.NotImplementedException();
        }
    }
}