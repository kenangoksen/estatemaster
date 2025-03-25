using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.DDLManipulations
{

    public class DropIndex : IDDLManipulation, IAlterSpecification, IDropIndex
    {

        private string tableName { get; set; }

        private string name { get; set; }

        public DropIndex(string tableName, string name)
        {
            this.tableName = tableName;
            this.name = name;
        }

        public string GetIndexName()
        {
            return name;
        }

        public string GetTableName()
        {
            return tableName;
        }
    }

}
