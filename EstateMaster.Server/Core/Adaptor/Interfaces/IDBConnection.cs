using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Interfaces
{

    public interface IDBConnection
    {

        string GetLastSQL();

        long Insert(string sql, Dictionary<string, dynamic> arguments = null);

        void ExecuteScript(string content);

        void Execute(string sql, Dictionary<string, dynamic> arguments = null);

        void ExecuteSP(string sql);

        List<Dictionary<string, dynamic>> Query(string sql, Dictionary<string, dynamic> arguments = null);

        void CloseTransaction();

        void BeginTransaction();

        void Commit();

        void Rollback();

        void DisposeAll();
    }

}
