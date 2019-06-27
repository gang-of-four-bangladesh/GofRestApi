namespace Gof.Api.Data
{
    using System.Threading.Tasks;
    
    public interface IDataContextFactory
    {
        Task<DataContext> Create();
    }
}