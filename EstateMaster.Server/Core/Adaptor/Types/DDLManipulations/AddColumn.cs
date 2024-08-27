using EstateMaster.Server.Adaptor.Helpers.Types;
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


    public class AddColumn: IDDLManipulation, IAlterSpecification, ICreateDefinition, IAddColumn
    {

        private ColumnItem column { get; set; }

        public AddColumn(ColumnItem column)
        {
            this.column = column;
        }

        public ColumnItem GetColumn()
        {
            return column;
        }
    }

}
