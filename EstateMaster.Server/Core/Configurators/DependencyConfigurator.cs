using Microsoft.Extensions.DependencyInjection; 

namespace EstateMaster.Server.Core.Configurators
{ 
    public class DependencyConfigurator : IConfigurator
    { 
        public void Configure(IServiceCollection services, AppSettings settings)
        {
            services.AddSingleton<IAppSettings>(i => settings);
          //  services.AddScoped<IEstateMaster.ServerVersion, EstateMaster.ServerVersion>();
        } 
    } 
}