using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.QueryTypes.WhereTypes
{

    [Serializable]
    public class WhereColumn : IQueryWhereSide
    {

        private string value;

        public WhereColumn(string value)
        {
            this.value = value;
        }

        public dynamic GetValue()
        {
            return value;
        }

        public bool IsValue()
        {
            return false;
        }

    }

}
