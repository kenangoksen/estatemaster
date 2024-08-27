using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.DDLManipulations
{

    public class AddUniqueIndex : IDDLManipulation, ICreateDefinition, IAddUniqueIndex
    {

        private string tableName { get; set; }

        private string indexName { get; set; }

        private List<ColumnItem> columns { get; set; }

        public AddUniqueIndex(string tableName, string indexName, List<ColumnItem> columns)
        {
            this.tableName = tableName;
            this.indexName = indexName;
            this.columns = columns;
        }

        public AddUniqueIndex(string tableName, string indexName, ColumnItem column)
        {
            this.tableName = tableName;
            this.indexName = indexName;
            columns = new List<ColumnItem>()
            {
                column
            };
        }

        public AddUniqueIndex(string tableName, string indexName, List<string> columnArray)
        {
            this.tableName = tableName;
            this.indexName = indexName;
            columns = new List<ColumnItem>();
            foreach (string columnName in columnArray)
            {
                columns.Add(new ColumnItem()
                {
                    name = columnName
                });
            }
        }

        public string GetIndexName()
        {
            return indexName;
        }

        public List<ColumnItem> GetColumns()
        {
            return columns;
        }

        public string GetTableName()
        {
            return tableName;
        }

    }

}
