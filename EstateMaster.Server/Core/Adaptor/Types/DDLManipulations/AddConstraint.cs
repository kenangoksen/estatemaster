using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.DDLManipulations
{


    public class AddConstraint : IDDLManipulation, IAlterSpecification, IAddConstraint
    {

        private ForeignKeyItem foreignKeyStruct { get; set; }

        public AddConstraint(ForeignKeyItem foreignKeyStruct)
        {
            this.foreignKeyStruct = foreignKeyStruct;
        }

        public ForeignKeyItem GetForeignKeyStruct()
        {
            return foreignKeyStruct;
        }
    }

}
