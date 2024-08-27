using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Shared
{

    public class TemplateCollection
    {

        private List<DataDefination> items { get; set; }

        public TemplateCollection()
        {
            items = new List<DataDefination>();
        }

        public TemplateCollection Add(DataDefination item)
        {
            items.Add(item);
            return this;
        }

        public List<DataDefination> ToList()
        {
            return items;
        }

        public string ToSQL()
        {
            string sql = "";
            foreach (DataDefination item in items)
            {
                sql += item.ToSQL() + ",";
            }

            if (sql.Length > 0)
            {
                sql = sql.Substring(0, sql.Length - 1);
            }

            return sql;
        }

    }

}
