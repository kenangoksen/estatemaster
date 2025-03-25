using EstateMaster.Server.Adaptor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateMaster.Server.Adaptor.Helpers.Extensions;
using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Adaptors.MySQL.Templates.DataTypeTemplates;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Responses;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;

namespace EstateMaster.Server.Adaptor.Adaptors.MySQL
{
    public class ColumnDefinationTemplate : DataDefination
    {

        private string template = @"`[NAME]` [DATA_TYPE] [NULLABLE] [AUTO_INCREMENT] [DEFAULT]";

        private ColumnItem column { get; set; }

        public ColumnDefinationTemplate(ColumnItem column)
        {
            this.column = column;
        }

        protected override string ToSQLBase()
        {
            DataDefination dataTypeTemplate = GetDataTypeTemplate(column);
            return template
                    .Replace("[NAME]", column.name)
                    .Replace("[DATA_TYPE]", dataTypeTemplate.ToSQL())
                    .Replace("[NULLABLE]", GetNullableSQL())
                    .Replace("[AUTO_INCREMENT]", GetAutoIncrementSQL())
                    .Replace("[DEFAULT]", GetDefaultIntValue())
                    .ClearDoubleSpace()
                    .ClearUnnecessarySpace();
        }

        public DataDefination GetDataTypeTemplate(ColumnItem column)
        {
            if (GetZeroTypes().Contains(column.dataType))
            {
                return new ZeroTemplate(column);
            }

            if (GetOnePointTypes().Contains(column.dataType))
            {
                return new OnePointTemplate(column);
            }

            if (GetTwoPointTypes().Contains(column.dataType))
            {
                return new TwoPointTemplate(column);
            }

            if (GetEnumTypes().Contains(column.dataType))
            {
                return new EnumTemplate(column);
            }

            throw new Exception("Type Not Found: " + column.dataType.ToString());

        }

        public static List<DataTypes> GetCharTypes()
        {
            return new List<DataTypes>()
            {
                DataTypes.CHAR,
                DataTypes.VARCHAR,
                DataTypes.BINARY,
                DataTypes.VARBINARY
            };
        }

        public static List<DataTypes> GetEnumTypes()
        {
            return new List<DataTypes>()
            {
                DataTypes.ENUM,
                DataTypes.SET
            };
        }

        public static List<DataTypes> GetTwoPointTypes()
        {
            return new List<DataTypes>()
            {
                DataTypes.DECIMAL,
                DataTypes.NUMERIC,
                DataTypes.FLOAT,
                DataTypes.DOUBLE
            };
        }

        public static List<DataTypes> GetOnePointTypes()
        {
            return new List<DataTypes>()
            {
                DataTypes.BIT,
                DataTypes.YEAR,
                DataTypes.CHAR,
                DataTypes.VARCHAR,
                DataTypes.BINARY,
                DataTypes.VARBINARY
            };
        }

        public static List<DataTypes> GetZeroTypes()
        {
            return new List<DataTypes>()
            {
                DataTypes.INT,
                DataTypes.SMALLINT,
                DataTypes.TINYINT,
                DataTypes.MEDIUMINT,
                DataTypes.BIGINT,
                DataTypes.DATE,
                DataTypes.DATETIME,
                DataTypes.TIME,
                DataTypes.BLOB,
                DataTypes.TINYBLOB,
                DataTypes.MEDIUMBLOB,
                DataTypes.LONGBLOB,
                DataTypes.TINYTEXT,
                DataTypes.TEXT,
                DataTypes.MEDIUMTEXT,
                DataTypes.LONGTEXT
            };
        }

        private string GetAutoIncrementSQL()
        {
            if (column.isAutoIncrement)
            {
                return "AUTO_INCREMENT";
            }
            return "";
        }

        private string GetNullableSQL()
        {
            if (column.isNullable)
            {
                return "NULL";
            }
            return "NOT NULL";
        }

        private string GetDefaultIntValue()
        {
            if (column.defaultIntValue > 0)
            {
                return "DEFAULT " + column.defaultIntValue;
            }
            return String.Empty;
        } 
    }
}
