using EstateMaster.Server.Adaptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;

namespace EstateMaster.Server.Adaptor.Types
{
    public class DropDatabase : IDDLAction, IDropDatabase, IIfExists
    {

        private string name { get; set; }
        private bool ifExistsStatus { get; set; }

        public DropDatabase(string name)
        {
            this.name = name;
            ifExistsStatus = false;
        }

        public string GetDatabaseName()
        {
            return name;
        }

        public void SetExists()
        {
            ifExistsStatus = true;
        }

        public bool IsExists()
        {
            return ifExistsStatus;
        }

    }
}
