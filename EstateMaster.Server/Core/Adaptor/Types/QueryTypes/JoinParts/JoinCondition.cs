using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.QueryTypes.JoinParts
{
    public class JoinCondition
    {

        private LogicTypes? prefix { get; set; }
        private ConditionTypes condition { get; set; }
        private IQueryWhereSide left { get; set; }
        private IQueryWhereSide right { get; set; }

        public JoinCondition()
        {

        }

        public static JoinCondition New(
            IQueryWhereSide left,
            ConditionTypes condition,
            IQueryWhereSide right,
            LogicTypes? prefix = null
        )
        {
            JoinCondition joinCondition = new JoinCondition();
            return joinCondition.Prefix(prefix)
                .Left(left)
                .Condition(condition)
                .Right(right);
        }

        public static JoinCondition New()
        {
            return new JoinCondition();
        }

        public JoinCondition Prefix(LogicTypes? value)
        {
            prefix = value;
            return this;
        }

        public JoinCondition Condition(ConditionTypes condition)
        {
            this.condition = condition;
            return this;
        }

        public JoinCondition Left(IQueryWhereSide left)
        {
            this.left = left;
            return this;
        }

        public JoinCondition Right(IQueryWhereSide right)
        {
            this.right = right;
            return this;
        }

        public LogicTypes? GetPrefix()
        {
            return prefix;
        }

        public ConditionTypes GetCondition()
        {
            return condition;
        }

        public IQueryWhereSide GetLeft()
        {
            return left;
        }

        public IQueryWhereSide GetRight()
        {
            return right;
        }

    }

}
