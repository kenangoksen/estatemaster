using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.DDLManipulations
{

    public class RenameIndex : IDDLManipulation, IAlterSpecification, IRenameIndex
    {

        private string oldIndexName { get; set; }

        private string newIndexName { get; set; }

        public RenameIndex(string oldIndexName, string newIndexName)
        {
            this.oldIndexName = oldIndexName;
            this.newIndexName = newIndexName;
        }

        public string GetOldName()
        {
            return oldIndexName;
        }

        public string GetNewName()
        {
            return newIndexName;
        }

    }

}
