using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.Types
{


    [JsonConverter(typeof(StringEnumConverter))]
    public enum DataTypes
    {
        // Numeric Types
        INT,
        SMALLINT,
        TINYINT,

        /// <summary>
        /// Sadece MySQL üzerinde kullanılıyor.
        /// </summary>
        MEDIUMINT,
        BIGINT,
        DECIMAL,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor ve DECIMAL alan türünün eşleniği
        /// </summary>
        DEC,
        NUMERIC,
        FLOAT,
        DOUBLE,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor.
        /// </summary>
        REAL,
        BIT,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor.
        /// </summary>
        SMALLMONEY,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor.
        /// </summary>
        MONEY,

        // Date-Time Types
        DATE,
        DATETIME,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor.
        /// </summary>
        DATETIME2,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor.
        /// </summary>
        SMALLDATETIME,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor.
        /// </summary>
        DATETIMEOFFSET,
        TIME,

        /// <summary>
        /// Sadece MySQL üzerinde kullanılıyor.
        /// </summary>
        YEAR,

        // String Types
        CHAR,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor.
        /// </summary>
        NCHAR,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor.
        /// </summary>
        NVARCHAR,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor.
        /// </summary>
        NTEXT,

        /// <summary>
        /// Sadece MSSQL üzerinde kullanılıyor.
        /// </summary>
        IMAGE,
        VARCHAR,
        BINARY,
        VARBINARY,
        TINYBLOB,
        BLOB,
        MEDIUMBLOB,
        LONGBLOB,
        TINYTEXT,
        TEXT,
        MEDIUMTEXT,
        LONGTEXT,

        // Çılgın atan alanlar
        ENUM,
        SET,
        MULTI_SELECTION

    }

}
