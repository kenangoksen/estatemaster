using EstateMaster.Server.Adaptor.Helpers.Types;
using EstateMaster.Server.Adaptor.Interfaces;
using EstateMaster.Server.Adaptor.Interfaces.DDLManipulations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class IndexItem : IAdaptorResponse
    {

        public string table { get; set; }
        public string keyName { get; set; }
        public string columnName { get; set; }
        public bool isWillCreate { get; set; }
        public bool isWillDelete { get; set; }

        public IndexItem()
        {
            isWillCreate = false;
            isWillDelete = false;
        }

        public static IndexItem MySQLConverter(Dictionary<string, dynamic> item)
        {
            return new IndexItem()
            {
                table = item["Table"],
                keyName = item["Key_name"],
                columnName = item["Column_name"],
            };
        }

        public static IndexItem MSSQL2017Converter(Dictionary<string, dynamic> item)
        {
            return new IndexItem()
            {
                table = item["TableName"],
                keyName = item["IndexName"],
                columnName = item["ColumnName"],
            };
        }
    }
}
