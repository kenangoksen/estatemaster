using EstateMaster.Server.Adaptor.EnumTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.QueryTypes
{

    [Serializable]
    public class Where
    {

        private QueryWhereType type;
        private string prefix = "AND";
        private string condition;
        private IQueryWhereSide left;
        private IQueryWhereSide right;
        private string leftBrackets { get; set; }
        private string rightBrackets { get; set; }

        private string subCommandPrefix;
        private IQueryWhereSide value1;
        private IQueryWhereSide value2;
        private List<IQueryWhereSide> _values; 

        public Where()
        {
            leftBrackets = "";
            rightBrackets = "";
        }

        public QueryWhereType Type()
        {
            return type;
        }

        public string Prefix()
        {
            return prefix;
        }

        public string Condition()
        {
            return condition;
        }

        public void AddLeftBrackets()
        {
            leftBrackets += "(";
        }

        public void AddRightBrackets()
        {
            rightBrackets += ")";
        }

        public string LeftBrackets()
        {
            return leftBrackets;
        }

        public string RightBrackets()
        {
            return rightBrackets;
        }

        public IQueryWhereSide Left()
        {
            return left;
        }

        public IQueryWhereSide Right()
        {
            return right;
        }

        public string SubPrefix()
        {
            return subCommandPrefix;
        }

        public IQueryWhereSide Value1()
        {
            return value1;
        }

        public IQueryWhereSide Value2()
        {
            return value2;
        }

        public List<IQueryWhereSide> Values()
        {
            return _values;
        }

        public Where SetType(QueryWhereType value)
        {
            type = value;
            return this;
        }

        public Where SetPrefix(string value)
        {
            prefix = value;
            return this;
        }

        public Where SetCondition(string value)
        {
            condition = value;
            return this;
        }

        public Where SetLeft(IQueryWhereSide value)
        {
            left = value;
            return this;
        }

        public Where SetRight(IQueryWhereSide value)
        {
            right = value;
            return this;
        }

        public Where SetSubPrefix(string value)
        {
            subCommandPrefix = value;
            return this;
        }

        public Where SetValue1(IQueryWhereSide value)
        {
            value1 = value;
            return this;
        }

        public Where SetValue2(IQueryWhereSide value)
        {
            value2 = value;
            return this;
        }

        public Where SetValues(List<IQueryWhereSide> values)
        {
            _values = values;
            return this;
        }

    }

}
