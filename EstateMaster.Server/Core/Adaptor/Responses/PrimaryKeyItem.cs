using EstateMaster.Server.Adaptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class PrimaryKeyItem: IAdaptorResponse
    {
        public string table { get; set; }
        public string column { get; set; }

        public static PrimaryKeyItem MySQLConverter(Dictionary<string, dynamic> item)
        {
            return new PrimaryKeyItem()
            {
                table = item["TABLE_NAME"],
                column = item["COLUMN_NAME"]
            };
        }

        public static PrimaryKeyItem MSSQL2017Converter(Dictionary<string, dynamic> item)
        {
            return new PrimaryKeyItem()
            {
                table = item["TABLE_NAME"],
                column = item["COLUMN_NAME"]
            };
        }

    }
}
