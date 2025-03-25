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
    /// DataType'i BIT olan alanlara default value atamasi yapabilmemiz icin hazirlandi.
    /// </summary>
    public class CreateBITField
    {

        private string tableName { get; set; }

        private string fieldName { get; set; }
        public string defaultValue { get; set; }

        public CreateBITField(string tableName, string fieldName, string defaultValue)
        {
            this.tableName = tableName;
            this.fieldName = fieldName;
            this.defaultValue = defaultValue;
        }

        public string GetFieldName()
        {
            return fieldName;
        }

        public string GetTableName()
        {
            return tableName;
        }

        public string GetDefaultValue()
        {
            return defaultValue;
        }
    }

}
