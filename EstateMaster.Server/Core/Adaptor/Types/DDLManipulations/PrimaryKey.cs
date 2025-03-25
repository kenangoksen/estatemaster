using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.DDLManipulations
{


    public class PrimaryKey : IDDLManipulation, ICreateDefinition, IPrimaryKey
    {

        private string fieldName { get; set; }

        public PrimaryKey(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public string GetName()
        {
            return fieldName;
        }

    }

}
