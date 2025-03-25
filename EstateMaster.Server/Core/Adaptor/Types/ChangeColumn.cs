using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types
{

    /// <summary>
    /// Sütunun adının değiştirilmesi işleminde kullanılır.
    /// </summary>
    public class ChangeColumn : IChangeColumn
    {

        private string tableName { get; set; }

        private string oldName { get; set; }

        private ColumnItem column { get; set; }

        public ChangeColumn(string tableName, string oldName, ColumnItem column)
        {
            this.tableName = tableName;
            this.oldName = oldName;
            this.column = column;
        }

        public string GetOldName()
        {
            return oldName;
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
