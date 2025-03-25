using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers
{
    public class LocalizedErrorMessage
    {
        public int code { get; set; }
        public List<string> arguments { get; set; }
        public Exception innerException { get; set; }
        
        public LocalizedErrorMessage()
        {
            arguments = new List<string>();
        }

    }

}
