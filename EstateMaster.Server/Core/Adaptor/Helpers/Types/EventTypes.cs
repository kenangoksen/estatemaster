using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.Types
{

    public enum EventTypes
    {

        ON_CLICK,
        ON_CHANGE,
        ON_KEYDOWN,
        ON_KEYPRESS,
        ON_KEYUP,
        ON_FOCUS,
        ON_BLUR,
        ON_LOAD,            // İlk yükleme olayı (C#)
        ON_BEFORE_SHOW_WIZARD,     // Kullanıcıya gösterilmeden önce (JS)
        ON_AFTER_SHOW_WIZARD,      // Kullanıcıya gönderildikten sonra (JS)
        ON_BEFORE_HIDE_WIZARD,     // Kullanıcıya gizlenmeden önce (JS)
        ON_AFTER_HIDE_WIZARD,      // Kullanıcıya gizlendikten sonra (JS)
        ON_BEFORE_SUBMIT,
        ON_SELECT_LIST_WIZARD_ROW,
        ON_UNSELECT_LIST_WIZARD_ROW

    }

}
