using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.Types
{

    /// <summary>
    /// MSSQL Server üzerinde auto increment alanlara dışarıdan
    /// değer gönderemiyoruz. Bu enum değeri bu işlemin veri tabanı kontrolünde 
    /// mi yoksa bizim kontrolümüzde mi yapılacağını belirtiyor.
    /// 
    /// ON: Veri tabanı kontrolünde, Primary Key verisi gönderemezsiniz.
    /// OFF: Bizim kontrolümüzde, Primary Key verisi göndermek zorundasınız.
    /// </summary>
    public enum AutoIncrementTypes
    {

        /// <summary>
        /// Veri tabanı kontrolünde, Primary Key verisi gönderemezsiniz.
        /// </summary>
        ON,

        /// <summary>
        /// Bizim kontrolümüzde, Primary Key verisi göndermek zorundasınız.
        /// </summary>
        OFF

    }
}
