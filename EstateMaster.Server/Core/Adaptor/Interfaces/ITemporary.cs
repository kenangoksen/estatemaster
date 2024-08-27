using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Interfaces
{

    public interface ITemporary
    {

        /// <summary>
        /// Tabloyu geçici olarak işaretlemek
        /// </summary>
        /// <returns></returns>
        void Temporary();

        /// <summary>
        /// Tablo geçici olarak mı işaretlendi?
        /// </summary>
        /// <returns></returns>
        bool IsTemporary();

    }

}
