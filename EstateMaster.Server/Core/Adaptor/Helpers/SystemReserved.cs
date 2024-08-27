using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers
{

    public class SystemReserved
    {

        public static List<string> reservedComponents { get; private set; }

        public static List<string> reservedTableNames { get; private set; }

        static SystemReserved()
        {
            reservedComponents = new List<string>()
            {
                "ID",
                "PASSWORD",
                "CREATE_AUTH_ID",
                "UPDATE_AUTH_ID",
                "DELETE_AUTH_ID",
                "CREATED_AT",
                "DELETED_AT",
                "UPDATED_AT",
                "filter"
            };

            reservedTableNames = new List<string>()
            {
                "SYSTEM",
                "LOGGEDUSER"
            };
        }

        public static List<string> GetReservedComponents()
        {
            return reservedComponents;
        }

        public static bool IsReservedTable(string name)
        {
            return reservedTableNames.Contains(name.ToUpper());
        }

        public static bool IsReservedComponent(string name)
        {
            return reservedComponents.Contains(name.ToUpper());
        }

    }

}
