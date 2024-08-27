using EstateMaster.Server.Adaptor.EnumTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Types.QueryTypes
{
    [Serializable]
    public class MathSelect
    {
        private string _firstColumn;
        private MathProcessTypes _mathProcess;
        private string _secondColumn;
        private double _value;
        private string _asName;

        public MathSelect(
            string firstColumn,
            MathProcessTypes mathProcess,
            string secondColumn,
            string asName)
        {
            _firstColumn = firstColumn;
            _mathProcess = mathProcess;
            _secondColumn = secondColumn;
            _asName = asName;
        }

        public MathSelect(
            string firstColumn,
            MathProcessTypes mathProcess,
            double value,
            string asName)
        {
            _firstColumn = firstColumn;
            _mathProcess = mathProcess;
            _value = value;
            _asName = asName;
        }

        public string FirstColumn()
        {
            return _firstColumn;
        }

        public MathProcessTypes MathType()
        {
            return _mathProcess;
        }

        public string SecondColumn()
        {
            return _secondColumn;
        }

        public double Value()
        {
            return _value;
        }

        public string AsName()
        {
            return _asName;
        }

    }
}


