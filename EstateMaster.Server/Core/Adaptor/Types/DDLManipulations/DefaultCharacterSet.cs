using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.DDLManipulations
{
    public class DefaultCharacterSet : ICreateDatabaseSpecification, IDefaultCharacterSet
    {

        public string value { get; set; }

        public DefaultCharacterSet(string value)
        {
            this.value = value;
        }

        public string GetValue()
        {
            return value;
        }

    }
}
