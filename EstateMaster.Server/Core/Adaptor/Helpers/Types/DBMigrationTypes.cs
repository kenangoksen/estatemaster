using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.Types
{
    public enum DBMigrationTypes
    {

        TABLE,
        TABLE_FIELD,
        FOREIGN_KEY,
        INDEX,
        UNIQUE_INDEX

    }
}
