using EstateMaster.Server.Adaptor.PSMigrator.Manager;
using EstateMaster.Server.Adaptor.PSMigrator.Types;
using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor;

using System.Collections.Generic;

namespace EstateMaster.Server.Adaptor.PSMigrator.Interfaces
{

    public interface IMigration
    {


        void Up(Query query, DDL ddl);


    }

}
