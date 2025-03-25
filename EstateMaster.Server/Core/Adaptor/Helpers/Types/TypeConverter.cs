using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.Types
{

    public class TypeConverter
    {

        private static Dictionary<Type, Dictionary<string, string>> aliases { get; set; }

        static TypeConverter()
        {
            aliases = new Dictionary<Type, Dictionary<string, string>>()
            {
                {
                    typeof(DataTypes),
                    new Dictionary<string, string>()
                    {
                        { "TIMESTAMP", "DATETIME" }
                    }
                }
            };
        }

        public static T To<T>(string value)
        {
            return To<T>(value, false);
        }

        public static T To<T>(int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        public static T To<T>(string value, bool ignoreCase)
        {
            if (value == null)
            {
                throw new Exception("TypeConverter Error: Cannot convert null to `" + typeof(T).Name + "`");
            }

            value = GetAlias(typeof(T), value);

            try
            {
                return (T)Enum.Parse(typeof(T), value, ignoreCase);
            }
            catch (Exception)
            {
                throw new Exception("TypeConverter Error: From `" + value + "` to `" + typeof(T).Name + "`");
            }
        }

        public static List<string> ToStringList<T>()
        {
            return Enum.GetNames(typeof(T)).ToList();
        }

        public static List<T> ToList<T>()
        {
            List<T> types = new List<T>();
            foreach (string type in  ToStringList<T>())
            {
                types.Add(To<T>(type));
            }
            return types;
        }

        private static string GetAlias(Type type, string value)
        {
            string upperedValue = value.ToUpper(new CultureInfo("en-gb"));
            if (aliases.ContainsKey(type) == false)
            {
                return value;
            }

            if (aliases[type].ContainsKey(upperedValue) == false)
            {
                return value;
            }

            return aliases[type][upperedValue];
        }

    }

}
