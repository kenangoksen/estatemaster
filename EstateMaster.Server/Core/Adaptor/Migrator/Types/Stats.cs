using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.PSMigrator.Types
{

    public class Stats
    {

        public int skipped { get; set; }
        public int executed { get; set; }

        public Stats()
        {
            skipped = 0;
            executed = 0;
        }

    }

}
