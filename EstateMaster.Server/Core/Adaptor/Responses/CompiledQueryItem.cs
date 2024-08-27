using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class CompiledQueryItem
    {

        public string sql { get; set; }
        public Dictionary<string, dynamic> parameters { get; set; }

        public CompiledQueryItem()
        {
            parameters = new Dictionary<string, dynamic>();
        }

    }
}
