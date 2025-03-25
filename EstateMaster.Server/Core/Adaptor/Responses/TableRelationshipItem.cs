using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{

    public class TableRelationshipItem
    {

        public string table { get; set; }
        public string column { get; set; }
        public string relatedTable { get; set; }
        public string relatedColumn { get; set; }

        public static TableRelationshipItem MySQLConverter(Dictionary<string, dynamic> item)
        {
            return new TableRelationshipItem()
            {
                table = item["TABLE_NAME"],
                column = item["COLUMN_NAME"],
                relatedTable = item["REFERENCED_TABLE_NAME"],
                relatedColumn = item["REFERENCED_COLUMN_NAME"],
            };
        }

        public static TableRelationshipItem MSSQL2017Converter(Dictionary<string, dynamic> item)
        {
            return new TableRelationshipItem()
            {
                table = item["TABLE_NAME"],
                column = item["COLUMN_NAME"],
                relatedTable = item["REFERENCED_TABLE_NAME"],
                relatedColumn = item["REFERENCED_COLUMN_NAME"],
            };
        }

    }

}
