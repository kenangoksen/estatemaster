using EstateMaster.Server.Adaptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{
    public class TriggerItem : IAdaptorResponse
    {

        public string name { get; set; }

        public string eventType { get; set; }

        public string tableName { get; set; }

        public string timeType { get; set; }

        public string definer { get; set; }

        public static TriggerItem MySQLConverter(Dictionary<string, dynamic> item)
        {
            return new TriggerItem()
            {
                name = item["TRIGGER_NAME"],
                definer = item["DEFINER"],
                tableName = item["EVENT_OBJECT_TABLE"],
                timeType = item["ACTION_TIMING"],
                eventType = item["EVENT_MANIPULATION"]
            };
        }

        public static TriggerItem MSSQL2017Converter(Dictionary<string, dynamic> item)
        {
            return new TriggerItem()
            {
                name = item["trigger_name"],
                tableName = item["table_name"],
                timeType = GetMSSQLTimeType(item),
                eventType = GetMSSQLEventType(item)
            };
        }

        private static string GetMSSQLEventType(Dictionary<string, dynamic> item)
        {
            if (item["isinsert"] == 1)
            {
                return "INSERT";
            }

            if (item["isupdate"] == 1)
            {
                return "UPDATE";
            }

            return "DELETE";
        }

        private static string GetMSSQLTimeType(Dictionary<string, dynamic> item)
        {
            if (item["isafter"] == 1)
            {
                return "AFTER";
            }
            return "BEFORE";
        }

    }

}
