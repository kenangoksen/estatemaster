using EstateMaster.Server.Adaptor.Helpers.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.ListHelpers
{
    public class SystemListHelper
    {

        public static ListTypes? GetSystemParentType(ListTypes type)
        {
            Dictionary<ListTypes?, ListTypes?> mapping = new Dictionary<ListTypes?, ListTypes?>()
            {
                { ListTypes.SystemCountry, null },
                { ListTypes.SystemRegion, ListTypes.SystemCountry },
                { ListTypes.SystemCity, ListTypes.SystemRegion },
                { ListTypes.SystemDistrict, ListTypes.SystemCity },
                { ListTypes.SystemLanguage, null }
            };
            if (mapping.ContainsKey(type) == false)
            {
                throw new Exception("Type not found: " + type.ToString());
            }
            return mapping[type];
        }

    }
}
