using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.DDLManipulations
{


    public class AddPrimaryKey : IDDLManipulation, IAlterSpecification, IAddPrimaryKey
    {

        private string fieldName { get; set; }

        public AddPrimaryKey(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public string GetName()
        {
            return fieldName;
        }

    }

}
