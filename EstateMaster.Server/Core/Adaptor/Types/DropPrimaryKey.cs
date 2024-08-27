using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types
{


    public class DropPrimaryKey : IDDLManipulation, IDropPrimaryKey
    {

        private string tableName { get; set; }

        public DropPrimaryKey(string tableName)
        {
            this.tableName = tableName;
        }

        public string GetTableName()
        {
            return tableName;
        }

    }

}
