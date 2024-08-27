using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AdaptorTypes
    {
        MySQL,
        MSSQL2017,
        MariaDB
    }

}
