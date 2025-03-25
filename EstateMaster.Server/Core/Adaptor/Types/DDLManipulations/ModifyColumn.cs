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

    public class ModifyColumn : IDDLManipulation, IModifyColumn
    {

        private string tableName { get; set; }

        private ColumnItem column { get; set; }

        public ModifyColumn(string tableName, ColumnItem column)
        {
            this.tableName = tableName;
            this.column = column;
        }
        
        public ColumnItem GetColumn()
        {
            return column;
        }

        public string GetTableName()
        {
            return tableName;
        }

    }

}
