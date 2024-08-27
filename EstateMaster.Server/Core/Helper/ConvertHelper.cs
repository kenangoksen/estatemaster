using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Helper
{ 
    public static class ConvertHelper
    { 
        public static bool ToBoolValue(string value)
        {
            if (value.ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static DateTime? ToDateTime(string value)
        {
            if (value.ToString() == String.Empty)
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(value);
            }
        }
        public static int BoolToInt(bool value)
        {
            if (value)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

}
