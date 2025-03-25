using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types
{

    public class AddIndex : IDDLManipulation, ICreateDefinition, IAddIndex
    {

        private string tableName { get; set; }

        private string indexName { get; set; }

        private ColumnItem column { get; set; }

        public AddIndex(string tableName, string indexName, ColumnItem column)
        {
            this.tableName = tableName;
            this.indexName = indexName;
            this.column = column;
        }

        public string GetColumnName()
        {
            return column.name;
        }

        public string GetIndexName()
        {
            return indexName;
        }

        public string GetTableName()
        {
            return tableName;
        }
    }

}
