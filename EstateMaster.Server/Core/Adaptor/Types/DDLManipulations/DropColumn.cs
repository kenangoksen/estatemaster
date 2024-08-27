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

    public class DropColumn : IDDLManipulation, IAlterSpecification, IDropColumn
    {

        private ColumnItem column { get; set; }

        public DropColumn(ColumnItem column)
        {
            this.column = column;
        }

        public string GetColumnName()
        {
            return column.name;
        }
    }

}
