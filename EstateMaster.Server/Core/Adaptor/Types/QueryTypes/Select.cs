using EstateMaster.Server.Adaptor.EnumTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.QueryTypes
{

    [Serializable]
    public class Select
    {

        private string _column;
        private string _asName;
        private AggregateFunctions _mathFunction;

        public Select(string column, string asName = null)
        {
            _column = column;
            _asName = asName;
            _mathFunction = AggregateFunctions.None;
        }

        public Select(string column, AggregateFunctions mathFunction, string asName = null)
        {
            _column = column;
            _asName = asName;
            _mathFunction = mathFunction;
        }

        public string Column()
        {
            return _column;
        }

        public string AsName()
        {
            return _asName;
        }

        public AggregateFunctions MathFunction()
        {
            return _mathFunction;
        }
    }
}
