using EstateMaster.Server.Adaptor.Helpers.ConnectionStringParsers;
using EstateMaster.Server.Adaptor.Helpers.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers
{

    public class ConnectionStringHelperFactory
    {

        public static ConnectionStringHelper GetInstance(AdaptorTypes adaptor, string raw)
        {
            switch (adaptor)
            {
                case AdaptorTypes.MySQL:
                    return new ConnectionStringHelper(new MySQLParser(), raw);
                case AdaptorTypes.MariaDB:
                    return new ConnectionStringHelper(new MySQLParser(), raw);
                case AdaptorTypes.MSSQL2017:
                    return new ConnectionStringHelper(new MSSQLParser(), raw);
                default:
                    throw new Exception("Type not found: " + adaptor);
            }
        }

    }

}
