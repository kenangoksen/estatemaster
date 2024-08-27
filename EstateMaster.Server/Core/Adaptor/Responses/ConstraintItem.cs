using EstateMaster.Server.Adaptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class ConstraintItem: IAdaptorResponse
    {

        public string schema { get; set; }
        public string name { get; set; }
        public string tableSchema { get; set; }
        public string tableName { get; set; }
        public string type { get; set; }

        public static ConstraintItem MySQLConverter(Dictionary<string, dynamic> item)
        {
            return new ConstraintItem()
            {
                schema = item["CONSTRAINT_SCHEMA"],
                name = item["CONSTRAINT_NAME"],
                tableSchema = item["TABLE_SCHEMA"],
                tableName = item["TABLE_NAME"],
                type = item["CONSTRAINT_TYPE"]
            };
        }

        public static ConstraintItem MSSQL2017Converter(Dictionary<string, dynamic> item)
        {
            return new ConstraintItem()
            {
                name = item["FK_Name"],
                tableName = item["FK_Table"],
                type = "FOREIGN KEY"
            };
        }


    }
}
