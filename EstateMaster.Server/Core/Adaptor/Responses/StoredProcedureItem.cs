using EstateMaster.Server.Adaptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class StoredProcedureItem: IAdaptorResponse
    {

        public string db { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public string definer { get; set; }

        public string createdAt { get; set; }

        public string updatedAt { get; set; }

        public static StoredProcedureItem MySQLConverter(Dictionary<string, dynamic> item)
        {
            return new StoredProcedureItem()
            {
                createdAt = item["Created"],
                db = item["Db"],
                definer = item["Definer"],
                name = item["Name"],
                type = item["Type"],
                updatedAt = item["Modified"]
            };
        }

        public static StoredProcedureItem MSSQL2017Converter(Dictionary<string, dynamic> item)
        {
            return new StoredProcedureItem()
            {
                createdAt = ToString(item["create_date"]),
                updatedAt = ToString(item["modify_date"]),
                name = item["object_name"],
                type = item["type"]
            };
        }

        private static string ToString(dynamic dynamic)
        {
            if (dynamic == null)
            {
                return "";
            }
            return dynamic.ToString();
        }
    }
}
