using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.ConnectionStringParsers
{

    public class MSSQLParser : IConnectionStringParser
    {
        private ConnectionString connectionString { get; set; }

        public string Compile()
        {
            if (connectionString.integratedSecurity != null)
            {
                return "Server={0};Database={1};Integrated Security={2};Pooling={3};"
                    .Replace("{0}", connectionString.server)
                    .Replace("{1}", connectionString.database)
                    .Replace("{2}", connectionString.integratedSecurity)
                    .Replace("{3}", connectionString.pooling);
            }

            return "Server={0};Database={1};User Id={2};Password={3};Pooling={4};"
                .Replace("{0}", connectionString.server)
                .Replace("{1}", connectionString.database)
                .Replace("{2}", connectionString.user)
                .Replace("{3}", connectionString.password)
                .Replace("{4}", connectionString.pooling);
        }

        public void SetConnectionString(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public void SetKeyValue(KeyValuePair<string, string> pair)
        {
            switch (pair.Key.ToLower(new CultureInfo("en-gb")))
            {
                case "server":
                    connectionString.server = pair.Value;
                    break;
                case "database":
                    connectionString.database = pair.Value;
                    break;
                case "user id":
                    connectionString.user = pair.Value;
                    break;
                case "password":
                    connectionString.password = pair.Value;
                    break;
                case "trusted_connection":
                    connectionString.trustedConnection = pair.Value;
                    break;
                case "integrated security":
                    connectionString.integratedSecurity = pair.Value;
                    break;
                case "pooling":
                    connectionString.pooling = pair.Value;
                    break;
                default:
                    throw new Exception("Key not found: " + pair.Key.ToLower(new CultureInfo("en-gb")));
            }
        }
    }

}
