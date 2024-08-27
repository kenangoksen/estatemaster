using System;
using EstateMaster.Server.Core.Migrations;
using EstateMaster.Server.Adaptor; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; 

namespace EstateMaster.Server.Core.Configurators
{

    public class MigrationConfigurator : IConfigurator
    {
        
        public void Configure(IServiceCollection services, AppSettings settings)
        {
            MigrationManager migrationManager = new MigrationManager(
                Factory.GetQuery(EstateMaster.Server.Adaptor.Helpers.Types.AdaptorTypes.MySQL, settings.Database.ConnectionString),
                Factory.GetDDL(EstateMaster.Server.Adaptor.Helpers.Types.AdaptorTypes.MySQL, settings.Database.ConnectionString)
            );
            migrationManager.Execute();
        }

    }

}