using EstateMaster.Server.Adaptor.Helpers.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.PSMigrator.Types
{

    public class DatabaseInformation
    {
        public string code { get; set; }
        public string name { get; set; }
        public string schema { get; set; }
        public string productionSchema { get; set; }
        public AdaptorTypes adaptor { get; set; }
        public int connectionId { get; set; }
        public string connectionString { get; set; }
        public DatabaseTypes type { get; set; }
        public List<string> executedMigrations { get; set; }

        public DatabaseInformation()
        {
            executedMigrations = new List<string>();
            connectionId = -1;
        }

        public bool IsNotExecuted(string migrationName)
        {
            return executedMigrations.Any(i => i.Trim() == migrationName) == false;
        }

    }

}
