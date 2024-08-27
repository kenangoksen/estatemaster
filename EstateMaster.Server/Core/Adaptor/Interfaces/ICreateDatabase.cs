using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using EstateMaster.Server.Adaptor.Shared;
using EstateMaster.Server.Adaptor.Types;
using System.Collections.Generic;

namespace EstateMaster.Server.Adaptor.Interfaces
{
    /// <summary>
    /// Alter Table işleminin hangi metotları içereceğini göstermektedir.
    /// </summary>
    public interface ICreateDatabase
    {

        List<ICreateDatabaseSpecification> Specifications();

        ICreateDatabase Specification(IDefaultCharacterSet item);

        ICreateDatabase Specification(IDefaultCollate item);

        string GetDefaultCollate();

        string GetDatabaseName();

    }
}