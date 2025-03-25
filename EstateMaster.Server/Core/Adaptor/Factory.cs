using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Connections;
using System; 
using EstateMaster.Server.Adaptor.Interfaces;

namespace EstateMaster.Server.Adaptor
{
    /// <summary>
    /// DDL ya da DML nesnelerini hızlı bir şekilde oluşturmak için kullanılır.
    /// </summary>
    public class Factory
    {

        /// <summary>
        /// DDL nesnesi oluşturmak için hangi veri tabanı türünün (MYSQL, MSSQL)
        /// kullanılacağı ve bağlantı bilgilerinin ne olduğunun söylenmesi zorunludur.
        /// </summary>
        /// <param name="adaptor"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DDL GetDDL(AdaptorTypes adaptor, string connectionString)
        {
            return new DDL(AdaptorFactory.GetDatabaseAdaptor(adaptor, connectionString));
        }

        /// <summary>
        /// Query nesnesi oluşturmak için kullanılır.
        /// </summary>
        /// <param name="adaptor"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static Query GetQuery(AdaptorTypes adaptor, string connectionString)
        {
            return new Query(AdaptorFactory.GetDatabaseAdaptor(adaptor, connectionString));
        }

        public static IDBConnection GetDatabaseConnection(AdaptorTypes adaptor, string connectionString)
        {
            switch (adaptor)
            {
                case AdaptorTypes.MySQL:
                    return new MySQLConnection(connectionString);
                case AdaptorTypes.MariaDB:
                    return new MySQLConnection(connectionString); 
                default:
                    throw new Exception("Type not found" + adaptor.ToString());
            }
        }

    }
}
