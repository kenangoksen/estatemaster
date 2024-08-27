using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.Types
{

    public enum EventActionTypes
    {

        RunWizardFieldFormulas,
        RunWizardFieldRules,
        RunWizardFormulas,
        RunWizardRules,
        RunWizardQueries,
        RunFormQueries,
        RunRemoveListSelection,
        RunRecordFetcher,
        RunUniqueGroupFetcher,
        RunSelectFirstRowOfList,
        RunWizardScripts,
        RunWizardExternalService

    }

}
