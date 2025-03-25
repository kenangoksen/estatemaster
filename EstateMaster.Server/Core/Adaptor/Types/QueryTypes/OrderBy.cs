using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.QueryTypes
{

    [Serializable]
    public class OrderBy
    {

        private string _column;
        private string _type;

        public OrderBy(string column, string type)
        {
            _column = column;
            _type = type;
        }

        public string Column()
        {
            if (_column.IndexOf(".") == -1)
            {
                return _column;
            }
            string[] parts = _column.Split('.');
            return parts[0] + "." + parts[1];
        }

        public string Type()
        {
            return _type;
        }

    }

}
