using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using EstateMaster.Server.Adaptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.DDLManipulations
{
    public class Collate : IAlterSpecification, ICreateDefinition, ICollate
    {

        public string value { get; set; }

        public Collate(string value)
        {
            this.value = value;
        }

        public string GetValue()
        {
            return value;
        }

    }

}
