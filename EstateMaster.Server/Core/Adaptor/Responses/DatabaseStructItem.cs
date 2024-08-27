using EstateMaster.Server.Adaptor.Helpers.Types;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EstateMaster.Server.Adaptor.Responses
{

    public class DatabaseStructItem
    {


        public DatabaseStructMetadataItem metadata { get; set; }

        public List<TableItem> tables { get; set; }

        public List<TableSizeInformation> tableSizeInformations { get; set; }

        public DatabaseStructItem(AdaptorTypes adaptor, string schema)
        {
            metadata = new DatabaseStructMetadataItem()
            {
                schema = schema,
                adaptor = adaptor
            };
            tables = new List<TableItem>();
            tableSizeInformations = new List<TableSizeInformation>();
        }

        public string ToJSON()
        {
            JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(this, _jsonSettings);
        }

        /// <summary>
        /// Adı verilen tabloyu getir.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public TableItem FindTable(string tableName)
        {
            return tables
                .Where(i => i.metadata.name == tableName)
                .FirstOrDefault();
        }

        /// <summary>
        /// Kullanıcının tanımladığı tabloları getir.
        /// </summary>
        /// <returns></returns>
        public List<TableItem> GetUserDefinedTables()
        {
            return tables.Where(i => i.metadata.name != "_psmigrations")
                .Where(i => i.metadata.name.Contains("sys_") == false)
                .ToList();
        }

    }

}
