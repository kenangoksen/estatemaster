using EstateMaster.Server.Adaptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;

namespace EstateMaster.Server.Adaptor.Types
{
    public class DropTable : IDDLAction, IDropTable, IIfExists, ITemporary
    {

        private string name { get; set; }
        private bool isIfExists { get; set; }
        private bool isTemporary { get; set; }

        public DropTable(string name)
        {
            this.name = name;
            isIfExists = false;
            isTemporary = false;
        }

        public string GetTableName()
        {
            return name;
        }

        public void Temporary()
        {
            isTemporary = true;
        }

        public bool IsTemporary()
        {
            return isTemporary;
        }

        public void SetExists()
        {
            isIfExists = true;
        }

        public bool IsExists()
        {
            return isIfExists;
        }

    }
}
