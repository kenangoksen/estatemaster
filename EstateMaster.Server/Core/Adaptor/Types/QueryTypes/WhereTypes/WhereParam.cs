using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.QueryTypes.WhereTypes
{
    [Serializable]
    public class WhereParam: IQueryWhereSide
    {

        private dynamic _value { get; set; }

        private bool isSpecial { get; set; }

        public WhereParam(dynamic value, bool isSpecial = false)
        {
            _value = value;
            this.isSpecial = isSpecial;
        }

        public dynamic GetValue()
        {
            if (_value == null)
            {
                return null;
            }
            return _value.ToString();
        }

        public bool IsSpecial()
        {
            return isSpecial;
        }

        public bool IsValue()
        {
            return true;
        }

    }
}
