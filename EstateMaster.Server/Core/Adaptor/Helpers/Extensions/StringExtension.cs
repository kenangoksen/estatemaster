using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.Extensions
{
    public static class StringExtension
    {

        public static string ClearDoubleSpace(this String value)
        {
            return Regex.Replace(value, @"\s+", " ")
                .Replace(") ;", ");")
                .Trim();
        }

        public static string ClearUnnecessarySpace(this String value)
        {
            return value.Replace(" ,", ",")
                .Replace("  ,", ",");
        }

        public static string ClearString(this String value)
        {
            return value.ClearDoubleSpace()
                .ClearUnnecessarySpace()
                .Trim();
        }

    }

}
