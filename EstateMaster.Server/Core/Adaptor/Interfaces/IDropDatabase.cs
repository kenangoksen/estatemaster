using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using EstateMaster.Server.Adaptor.Shared;
using EstateMaster.Server.Adaptor.Types;
using System.Collections.Generic;

namespace EstateMaster.Server.Adaptor.Interfaces
{
    /// <summary>
    /// Drop Database işleminin hangi metotları içereceğini göstermektedir.
    /// </summary>
    public interface IDropDatabase
    {

        string GetDatabaseName();

    }

}