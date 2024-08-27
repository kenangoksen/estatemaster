using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.Types
{

    public enum CommandType
    {

        START,
        SUM,
        IF,
        SUBTRACT,
        MULTIPLY,
        DIVIDE,
        AVG,
        LENGTH,
        SYNC,
        CONCAT,
        SUBSTR,
        DATEDIFF,
        ADDDAYS,
        ADDMONTH,
        ADDYEAR,
        CONTAINS,
        LIST_LENGTH,
        SPACE,
        QDATA_CELL_VALUE,
        QDATA_ROW_COUNT

    }

}
