using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.QueryTypes.WhereTypes
{
    [Serializable]
    public class WhereValue : IQueryWhereSide
    {

        private dynamic _value;

        public WhereValue(dynamic value)
        {
            _value = value;
        }

        public dynamic GetValue()
        {
            return _value;
        }

        public bool IsValue()
        {
            return true;
        }

    }
}
