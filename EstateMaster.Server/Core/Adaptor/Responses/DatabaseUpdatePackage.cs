using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Responses
{

    public class Operation<T>
    {

        public List<T> create { get; set; }
        public List<T> delete { get; set; }
        public List<T> update { get; set; }

        public Operation() 
        {
            create = new List<T>();
            delete = new List<T>();
            update = new List<T>();
        }

    }

    public class DatabaseUpdatePackage
    {

        public List<string> dataTables { get; set; }

        public Operation<TableItem> tables { get; set; }

        public Operation<ColumnItem> columns { get; set; }

        public Operation<ForeignKeyItem> foreignKeys { get; set; }

        public Operation<IndexItem> indexes { get; set; }

        public Operation<IndexItem> uniqueIndexes { get; set; }

        public Dictionary<string, string> namedTables { get; set; }

        public Dictionary<string, Dictionary<string, string>> namedColumns { get; set; }

        public DatabaseUpdatePackage()
        {
            tables = new Operation<TableItem>();
            columns = new Operation<ColumnItem>();
            foreignKeys = new Operation<ForeignKeyItem>();
            indexes = new Operation<IndexItem>();
            uniqueIndexes = new Operation<IndexItem>();
            dataTables = new List<string>();
            namedTables = new Dictionary<string, string>();
            namedColumns = new Dictionary<string, Dictionary<string, string>>();
        }

    }

}
