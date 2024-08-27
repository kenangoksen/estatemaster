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
    public class ChangeColumnSpecial : IChangeColumnSpecial
    {

        private string tableName { get; set; }

        private string oldName { get; set; }
        private string isNull { get; set; }
        private string defaultValue { get; set; }

        public ChangeColumnSpecial(string tableName, string oldName, string isNull, string defaultValue)
        {
            this.tableName = tableName;
            this.oldName = oldName;
            this.isNull = isNull;
            this.defaultValue = defaultValue;
        }

        public string GetOldName()
        {
            return oldName;
        }
        public string GetTableName()
        {
            return tableName;
        }

        public string GetIsNull()
        {
            return isNull;
        }

        public string GetDefault()
        {
            return defaultValue;
        }
    }

}
