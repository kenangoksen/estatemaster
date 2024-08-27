using EstateMaster.Server.Adaptor.Helpers.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.PSMigrator.Manager
{

    public class DatabaseConnection
    {
        public int id { get; set; }
        public string code { get; set; }
        public string schema { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int port { get; set; }
        public string connectionString { get; set; }
        public AdaptorTypes adaptor { get; set; }
    }

}
