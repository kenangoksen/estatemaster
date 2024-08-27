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

    public class TwoPointTemplate : DataDefination, IDataTypeTemplate
    {

        private string template = "[STRUCTURE]([ONE], [TWO])";

        private ColumnItem column { get; set; }

        public TwoPointTemplate(ColumnItem column)
        {
            this.column = column;
        }

        protected override string ToSQLBase()
        {
            return template
                .Replace("[STRUCTURE]", column.dataType.ToString())
                .Replace("[ONE]", column.maxLength.ToString())
                .Replace("[TWO]", column.scale.ToString())
                .Trim();
        }
    }

}
