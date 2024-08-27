using Microsoft.Extensions.DependencyInjection;

namespace EstateMaster.Server.Core.Configurators
{

    public interface IConfigurator
    {

        void Configure(IServiceCollection services, AppSettings settings);
        
    }

}