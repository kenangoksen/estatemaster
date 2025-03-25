using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Types;
using System.Collections.Generic;

namespace EstateMaster.Server.Adaptor.Interfaces.CreateTableParts
{
    public interface ICreateDefinitionPart
    {

        int Count();

        List<IAlterSpecification> ToList();

    }
}