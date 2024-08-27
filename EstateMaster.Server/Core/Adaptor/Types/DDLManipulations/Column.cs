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


    public class Column : IDDLManipulation, IAlterSpecification, ICreateDefinition, IColumn
    {

        private ColumnItem column { get; set; }

        public Column(ColumnItem column)
        {
            this.column = column;
        }

        public ColumnItem GetColumn()
        {
            return column;
        }

        public static List<IColumn> Convert(List<ColumnItem> items)
        {
            List<IColumn> response = new List<IColumn>();
            foreach (ColumnItem item in items)
            {
                response.Add(new Column(item));
            }
            return response;
        }


    }

}
