using EstateMaster.Server.Adaptor.Helpers.ConnectionStringParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers
{

    public class ConnectionStringHelper
    {

        private IConnectionStringParser parser { get; set; }

        private ConnectionString connectionString { get; set; }

        private string raw { get; set; }

        public ConnectionStringHelper(IConnectionStringParser parser, string raw)
        {
            this.raw = raw;
            this.parser = parser;
            connectionString = new ConnectionString();
            this.parser.SetConnectionString(connectionString);
            ParseValues(FilterLines(GetLines()));
        }

        public string GetServer()
        {
            return connectionString.server;
        }

        public void SetServer(string value)
        {
            connectionString.server = value;
        }

        public string GetUser()
        {
            return connectionString.user;
        }

        public void SetUser(string value)
        {
            connectionString.user = value;
        }

        public string GetPassword()
        {
            return connectionString.password;
        }

        public void SetPassword(string value)
        {
            connectionString.password = value;
        }

        public string GetPersistSecurityInfo()
        {
            return connectionString.persistsecurityinfo;
        }

        public void SetPersistSecurityInfo(string value)
        {
            connectionString.persistsecurityinfo = value;
        }

        public string GetDatabase()
        {
            return connectionString.database;
        }

        public void SetDatabase(string value)
        {
            connectionString.database = value;
        }

        public string GetCharset()
        {
            return connectionString.charset;
        }

        public string Compile()
        {
            return parser.Compile();
        }

        public void SetCharset(string value)
        {
            connectionString.charset = value;
        }

        private void ParseValues(List<string> lines)
        {
            foreach (string line in lines)
            {
                parser.SetKeyValue(ToKeyValuePair(line));
            }
        }

        private List<string> FilterLines(List<string> lines)
        {
            return lines
                .Where(i => i.Length > 0)
                .ToList();
        }

        private void SetKeyValue(KeyValuePair<string, string> pair)
        {
            switch (pair.Key.ToUpper())
            {
                case "SERVER":
                    connectionString.server = pair.Value;
                    break;
                case "USER ID":
                    connectionString.user = pair.Value;
                    break;
                case "PWD":
                    connectionString.password = pair.Value;
                    break;
                case "PERSISTSECURITYINFO":
                    connectionString.persistsecurityinfo = pair.Value;
                    break;
                case "DATABASE":
                    connectionString.database = pair.Value;
                    break;
                case "CHARSET":
                    connectionString.charset = pair.Value;
                    break;
                default:
                    throw new Exception("Key not found: " + pair.Key);
            }
        }

        private KeyValuePair<string, string> ToKeyValuePair(string value)
        {
            return new KeyValuePair<string, string>(
                value.Substring(0, value.IndexOf("=")),
                value.Substring(value.IndexOf("=") + 1)
            );
        }

        private List<string> GetLines()
        {
            return raw.Split(';')
                .ToList();
        }

    }

}
