using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using EstateMaster.Server.Adaptor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Adaptors.MySQL.Templates.DataTypeTemplates
{

    public class ZeroTemplate : DataDefination, IDataTypeTemplate
    {

        private ColumnItem column { get; set; }

        public ZeroTemplate(ColumnItem column)
        {
            this.column = column;
        }

        protected override string ToSQLBase()
        {
            return column.dataType.ToString();
        }
    }

}
