using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Interfaces
{

    public interface IIfExists
    {

        /// <summary>
        /// Tablo daha önce oluşturulmamış ise oluşturulmasını sağlamak.
        /// </summary>
        /// <returns></returns>
        void SetExists();

        /// <summary>
        /// Daha önce oluşturulup oluşturulmadığı dikkate alınıyor mu?
        /// </summary>
        /// <returns></returns>
        bool IsExists();

    }

}
