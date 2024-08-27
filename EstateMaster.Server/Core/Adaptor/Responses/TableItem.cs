using EstateMaster.Server.Adaptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class TableItem: IAdaptorResponse
    {

        public List<ColumnItem> columns { get; set; }
        public List<Dictionary<string, dynamic>> items { get; set; }
        public TableItem newNamedTable { get; set; }
        public bool isChanged { get; set; }
        public TableMetadataItem metadata { get; set; }
        public List<IndexItem> indexes { get; set; }
        public List<ForeignKeyItem> foreignKeys { get; set; }
        public List<IndexItem> uniqueIndexes { get; set; }

        public TableItem()
        {
            metadata = new TableMetadataItem();
            newNamedTable = null;
            columns = new List<ColumnItem>();
            items = new List<Dictionary<string, dynamic>>();
            indexes = new List<IndexItem>();
            foreignKeys = new List<ForeignKeyItem>();
            uniqueIndexes = new List<IndexItem>();
        }

        public ColumnItem FindColumn(string columnName)
        {
            return columns
                .Where(i => i.name == columnName)
                .FirstOrDefault();
        }

        public static TableItem MySQLConverter(Dictionary<string, dynamic> item)
        {
            return new TableItem()
            {
                metadata = new TableMetadataItem()
                {
                    name = item["TABLE_NAME"],
                    engine = item["ENGINE"],
                    collation = item["TABLE_COLLATION"],
                    charset = item["CHARSETNAME"]
                }
            };
        }

        public static TableItem MSSQL2017Converter(Dictionary<string, dynamic> item)
        {
            return new TableItem()
            {
                metadata = new TableMetadataItem()
                {
                    name = item["TABLE_NAME"]
                }
            };
        }

    }
}
