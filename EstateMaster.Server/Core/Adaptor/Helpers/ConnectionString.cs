using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers
{

    public class ConnectionString
    {

        public string pooling { get; set; }

        public string sid { get; set; }

        public string direct { get; set; }

        public string server { get; set; }

        public string user { get; set; }

        public string password { get; set; }

        public string persistsecurityinfo { get; set; }

        public string database { get; set; }

        public string charset { get; set; }

        public string trustedConnection { get; set; }

        public string integratedSecurity { get; set; }

        public string port { get; set; }

        public ConnectionString()
        {
            pooling = "True";
        }

    }


}
