using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.DDLManipulations
{

    public class RenameTable : IDDLManipulation, IRenameTable
    {

        private string oldTableName { get; set; }

        private string newTableName { get; set; }

        public RenameTable(string oldTableName, string newTableName)
        {
            this.oldTableName = oldTableName;
            this.newTableName = newTableName;
        }

        public string GetNewName()
        {
            return newTableName;
        }

        public string GetOldName()
        {
            return oldTableName;
        }

    }

}
