using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.ConnectionStringParsers
{

    public class MySQLParser : IConnectionStringParser
    {
        private ConnectionString connectionString { get; set; }

        public string Compile()
        {
            if (connectionString.port == null)
            {
                connectionString.port = "3306";
            }

            string template = "server={0};user id={1};Pwd={2};persistsecurityinfo={3};database={4};charset={5};port={6};Pooling={7}";
            return template.Replace("{0}", connectionString.server)
                .Replace("{1}", connectionString.user)
                .Replace("{2}", connectionString.password)
                .Replace("{3}", connectionString.persistsecurityinfo)
                .Replace("{4}", connectionString.database)
                .Replace("{5}", connectionString.charset)
                .Replace("{6}", connectionString.port)
                .Replace("{7}", connectionString.pooling);
        }

        public void SetConnectionString(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public void SetKeyValue(KeyValuePair<string, string> pair)
        {
            switch (pair.Key.ToLower())
            {
                case "server":
                    connectionString.server = pair.Value;
                    break;
                case "user id":
                case "uid":
                    connectionString.user = pair.Value;
                    break;
                case "pwd":
                    connectionString.password = pair.Value;
                    break;
                case "persistsecurityinfo":
                    connectionString.persistsecurityinfo = pair.Value;
                    break;
                case "database":
                    connectionString.database = pair.Value;
                    break;
                case "charset":
                    connectionString.charset = pair.Value;
                    break;
                case "port":
                    connectionString.port = pair.Value;
                    break;
                case "pooling":
                    connectionString.pooling = pair.Value;
                    break;
                default:
                    throw new Exception("Key not found: " + pair.Key);
            }
        }
    }

}
