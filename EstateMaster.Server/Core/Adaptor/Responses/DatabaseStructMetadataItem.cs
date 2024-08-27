using EstateMaster.Server.Adaptor.Helpers.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class DatabaseStructMetadataItem
    {

        [JsonConverter(typeof(StringEnumConverter))]
        public AdaptorTypes adaptor { get; set; }

        public string softwareVersion { get; set; }

        public string schema { get; set; }

        [NonSerialized]
        public string connectionString;


    }
}
