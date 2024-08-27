using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class ColumnItem : IAdaptorResponse, IDDLManipulation, IAlterSpecification, ICreateDefinition
    {
        public string name { get; set; }
        public string defaultValue { get; set; }
        public int defaultIntValue { get; set; }
        public bool isNullable { get; set; } 
        public DataTypes dataType { get; set; }
        public Int64? maxLength { get; set; }
        public Int64? scale { get; set; }
        public string type { get; set; }
        public string tableName { get; set; }
        public string oldName { get; set; }
        public string characterSetName { get; set; }
        public string collationName { get; set; }
        public bool isUnique { get; set; }
        public bool isPrimaryKey { get; set; }
        public bool isAutoIncrement { get; set; }
        public bool isKey { get; set; }
        public ColumnItem newNamedColumn { get; set; }
        public string indexName { get; set; }
        public TableItem table { get; set; }
        public List<string> enumValues { get; set; }
        /// <summary>
        /// TEXT, MEDIUMTEXT, LONGTEXT gibi MySQL alanları MSSQL üzerinde 
        /// VARCHAR olarak belirtilir. Eğer özel bir boyut girilmiyorsa ve
        /// ihtiyaç olan maksimum alanın kullanılması isteniyorsa bu değişkenin
        /// işaretlenmesi gerekmektedir. Bu değişken işaretlendiğinde ilgili
        /// alan MSSQL üzerinde VARCHAR(MAX) olarak oluşturulacaktır. 
        /// </summary>
        public bool isMSSQLMaxField { get; set; }

        [Obsolete("Bu bölüm henüz aktif olarak çalışmıyor.")]
        public string after { get; set; }

        public ColumnItem()
        {
            newNamedColumn = null;
            isMSSQLMaxField = false;
        }

        public static ColumnItem MySQLConverter(Dictionary<string, dynamic> item)
        {

            ColumnItem response = new ColumnItem()
            {
                name = GetKeyIfExists(item, "COLUMN_NAME"),
                defaultValue = GetKeyIfExists(item, "COLUMN_DEFAULT"),
                defaultIntValue = GetKeyIfExists(item, "COLUMN_DEFAULT"),
                isNullable = GetKeyIfExists(item, "IS_NULLABLE") == "YES",
                dataType = TypeConverter.To<DataTypes>(GetKeyIfExists(item, "DATA_TYPE"), true),
                maxLength = ToULong(GetKeyIfExists(item, "CHARACTER_MAXIMUM_LENGTH")),
                type = GetKeyIfExists(item, "COLUMN_TYPE"),
                characterSetName = GetKeyIfExists(item, "CHARACTER_SET_NAME"),
                collationName = GetKeyIfExists(item, "COLLATION_NAME"),
                tableName = GetKeyIfExists(item, "TABLE_NAME"),
                isAutoIncrement = GetKeyIfExists(item, "EXTRA") == "auto_increment",
                isPrimaryKey = GetKeyIfExists(item, "COLUMN_KEY") == "PRI",
                isUnique = GetKeyIfExists(item, "COLUMN_KEY") == "UNI",
                isKey = GetKeyIfExists(item, "COLUMN_KEY") == "MUL",
                indexName = GetKeyIfExists(item, "C_INDEX_NAME"),
                table = new TableItem()
                {
                    metadata = new TableMetadataItem()
                    {
                        name = GetKeyIfExists(item, "TABLE_NAME"),
                        engine = GetKeyIfExists(item, "TABLE_ENGINE"),
                        collation = GetKeyIfExists(item, "TABLE_COLLATION"),
                        charset = GetKeyIfExists(item, "CHARSETNAME"),
                    }
                }
            };


            if (response.dataType == DataTypes.BIT)
            {
                response.maxLength = 1;
                if (response.defaultValue == "b'0'")
                {
                    response.defaultValue = "0";
                }
                else if (response.defaultValue == "b'1'")
                {
                    response.defaultValue = "1";
                }
            }

            return response;
        }

        private static dynamic GetKeyIfExists (Dictionary<string, dynamic> item, string key)
        {
            if (item.Keys.Contains(key))
            {
                return item[key];
            }
            return null;
        }

        public static ColumnItem MSSQL2017Converter(Dictionary<string, dynamic> item)
        {
            Dictionary<string, string> dataTypeMap = new Dictionary<string, string>()
            {
                { "NTEXT", "VARCHAR" },
                { "REAL", "FLOAT" },
            };
            string dataTypeAsString = GetKeyIfExists(item, "DATA_TYPE");
            dataTypeAsString = dataTypeAsString.ToUpper(new CultureInfo("en-gb"));
            if (dataTypeMap.ContainsKey(dataTypeAsString))
            {
                dataTypeAsString = dataTypeMap[dataTypeAsString];
            }

            ColumnItem response = new ColumnItem()
            {
                name = GetKeyIfExists(item, "COLUMN_NAME"),
                defaultValue = GetKeyIfExists(item, "COLUMN_DEFAULT"),
                defaultIntValue = GetKeyIfExists(item, "COLUMN_DEFAULT"),
                isNullable = GetKeyIfExists(item, "IS_NULLABLE") == "YES",
                dataType = TypeConverter.To<DataTypes>(dataTypeAsString, true),
                maxLength = ToULong(GetKeyIfExists(item, "CHARACTER_MAXIMUM_LENGTH")),
                type = GetKeyIfExists(item, "DATA_TYPE"),
                characterSetName = GetKeyIfExists(item, "CHARACTER_SET_NAME"),
                collationName = GetKeyIfExists(item, "COLLATION_NAME"),
                tableName = GetKeyIfExists(item, "TABLE_NAME"),
                isAutoIncrement = GetKeyIfExists(item, "is_auto_increment") == 1,
                isPrimaryKey = GetKeyIfExists(item, "is_primary_key") == 1,
                isUnique = GetKeyIfExists(item, "is_unique") == 1,
                isKey = GetKeyIfExists(item, "is_indexed") == 1,
                indexName = GetKeyIfExists(item, "index_name"),
                table = new TableItem()
                {
                    metadata = new TableMetadataItem()
                    {
                        name = GetKeyIfExists(item, "TABLE_NAME")
                    }
                }
            };


            if (response.dataType == DataTypes.BIT)
            {
                response.maxLength = 1;
                if (response.defaultValue == "b'0'")
                {
                    response.defaultValue = "0";
                }
                else if (response.defaultValue == "b'1'")
                {
                    response.defaultValue = "1";
                }
            }

            return response;
        }

        private static Int64? ToULong(dynamic value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return System.Convert.ToInt64(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
