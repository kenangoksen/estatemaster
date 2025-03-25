using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.ConnectionStringParsers
{

    public interface IConnectionStringParser
    {

        void SetConnectionString(ConnectionString connectionString);

        void SetKeyValue(KeyValuePair<string, string> pair);

        string Compile();

    }

}
