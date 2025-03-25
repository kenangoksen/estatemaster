using EstateMaster.Server.Adaptor.Adaptors.MySQL;
using EstateMaster.Server.Adaptor.Connections;
using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Shared;
using System;

namespace EstateMaster.Server.Adaptor
{ 
    public class AdaptorFactory
    { 
        public static IDatabaseAdaptor GetDatabaseAdaptor(AdaptorTypes adaptor, string connectionString)
        {
            switch (adaptor)
            {
                case AdaptorTypes.MySQL:
                    return new MySQLAdaptor(new MySQLConnection(connectionString));
                case AdaptorTypes.MariaDB:
                    return new MySQLAdaptor(new MySQLConnection(connectionString)); 
                default:
                    throw new Exception("Type not found" + adaptor.ToString());
            }
        }  
    } 
}
