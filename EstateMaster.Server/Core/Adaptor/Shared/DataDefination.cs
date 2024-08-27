using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EstateMaster.Server.Adaptor.Helpers.Extensions;

namespace EstateMaster.Server.Adaptor.Shared
{

    public abstract class DataDefination
    {

        protected abstract string ToSQLBase();

        public string ToSQL()
        {
            string value = ToSQLBase()
                .Replace(Environment.NewLine, " ");

            return value.ClearDoubleSpace();
        }

        protected void ValidateCollection(TemplateCollection collection, Type contract)
        {
            foreach (DataDefination item in collection.ToList())
            {
                if (item.GetType().GetInterfaces().Contains(contract) == false)
                {
                    throw new TypeLoadException("It is not the accepted type: " + contract.ToString());
                }
            }
        }


    }

}
