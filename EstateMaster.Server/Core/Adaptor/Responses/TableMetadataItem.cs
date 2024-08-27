using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{

    public class TableMetadataItem
    {

        public string name { get; set; }
        public string engine { get; set; }
        public string collation { get; set; }
        public string oldName { get; set; }
        public string charset { get; set; }

    }

}
