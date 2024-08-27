using EstateMaster.Server.Adaptor.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class ForeignKeyItem: IAdaptorResponse
    {

        public string constraintName { get; set; }

        public ForeignKeyFieldItem main { get; set; }

        public ForeignKeyFieldItem referenced { get; set; }

        public bool IsUpdatable(List<TableItem> tables)
        {
            if (IsDefined(tables, main.tableName) == false)
            {
                return false;
            }

            return IsDefined(tables, referenced.tableName);
        }

        private bool IsDefined(List<TableItem> tables, string name)
        {
            return tables
                .Where(i => i.metadata.name == main.tableName)
                .Count() > 0;
        }

        public static ForeignKeyItem MySQLConverter(Dictionary<string, dynamic> item)
        {
            return new ForeignKeyItem()
            {
                constraintName = item["CONSTRAINT_NAME"],
                main = new ForeignKeyFieldItem()
                {
                    tableName = item["TABLE_NAME"],
                    columnName = item["COLUMN_NAME"]
                },
                referenced = new ForeignKeyFieldItem()
                {
                    tableName = item["REFERENCED_TABLE_NAME"],
                    columnName = item["REFERENCED_COLUMN_NAME"]
                }
            };
        }

        public static ForeignKeyItem MSSQL2017Converter(Dictionary<string, dynamic> item)
        {
            return new ForeignKeyItem()
            {
                constraintName = item["FK_Name"],
                main = new ForeignKeyFieldItem()
                {
                    tableName = item["FK_Table"],
                    columnName = item["FK_Column"]
                },
                referenced = new ForeignKeyFieldItem()
                {
                    tableName = item["PK_Table"],
                    columnName = item["PK_Column"]
                }
            };
        }


    }
}
