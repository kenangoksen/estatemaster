using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types
{

    public class DropForeignKey : IDDLManipulation, IDropForeignKey
    {

        private string tableName { get; set; }

        private string name { get; set; }

        public DropForeignKey(string tableName, string name)
        {
            this.tableName = tableName;
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public string GetTableName()
        {
            return tableName;
        }

    }

}
