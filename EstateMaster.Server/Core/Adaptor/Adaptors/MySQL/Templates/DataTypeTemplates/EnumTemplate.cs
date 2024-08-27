using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Shared;
using EstateMaster.Server.Adaptor.Responses;

namespace EstateMaster.Server.Adaptor.Adaptors.MySQL.Templates.DataTypeTemplates
{

    public class EnumTemplate : DataDefination, IDataTypeTemplate
    {

        private ColumnItem column { get; set; }

        public EnumTemplate(ColumnItem column)
        {
            this.column = column;
        }

        protected override string ToSQLBase()
        {
            string sql = column.dataType.ToString() + "(";

            foreach (string value in column.enumValues)
            {
                sql += "'" + value + "',";
            }

            if (column.enumValues.Count > 0)
            {
                sql = sql.Substring(0, sql.Length - 1);
            }

            return sql.Trim() + ")";
        }
    }

}
