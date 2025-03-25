using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Types.QueryTypes.JoinParts;
using EstateMaster.Server.Adaptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.QueryTypes
{

    public class Join
    {

        private JoinTypes type { get; set; }

        private string tableName { get; set; }

        private string alias { get; set; }

        private List<JoinCondition> conditions { get; set; }

        public Join()
        {
            conditions = new List<JoinCondition>();
        }

        public static Join New()
        {
            return new Join();
        }

        public Join Type(JoinTypes type)
        {
            this.type = type;
            return this;
        }

        public Join Table(string tableName)
        {
            this.tableName = tableName;
            return this;
        }

        public Join As(string alias)
        {
            this.alias = alias;
            return this;
        }

        public Join AddCondition(JoinCondition condition)
        {
            conditions.Add(condition);
            return this;
        }

        public Join On(Func<Join, Join> callback)
        {
            callback(this);
            return this;
        }

        public JoinCondition NewCondition()
        {
            JoinCondition condition = new JoinCondition();
            conditions.Add(condition);
            return conditions[conditions.Count - 1];
        }

        public JoinTypes GetJoinType()
        {
            return type;
        }

        public string GetTableName()
        {
            return tableName;
        }

        public string GetAlias()
        {
            return alias;
        }

        public List<JoinCondition> GetConditions()
        {
            return conditions;
        }

    }

}
