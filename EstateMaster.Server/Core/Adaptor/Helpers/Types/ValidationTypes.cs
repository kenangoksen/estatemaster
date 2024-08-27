using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateMaster.Server.Adaptor.Helpers.Types
{

    public enum ValidationTypes
    {

        IsRequired,
        Email,
        MinLength,
        MaxLength,
        Alpha,
        AlphaNumeric,
        Int,
        LessThan,
        GreaterThan,
        Mask,
        NumRows,
        Uppercase,
        ListSelect,
        ListNothing,
        ListAll,
        RegexChar,
        RegexString,
        FirstDayOfWeek,
        DateFormat,
        Alignment,
        Hidden,
        NotActive,
        DefaultValue,
        ShowCode,
        ShowTitle,
        DecimalMark,
        CurrencyCode,
        DisplayDecimals,
        DisplayDigits,
        DigitMark,
        OnChange,
        FilterList,
        FloatType,
        RecordFetchBox,
        EmptyWhenHidden,
        Password,
        IsRequireSeconds,
        TimeSelection,
        TimeFormat,
        RecordFetchIsRequired,
        UniqueGroupFetchBox,
        Sort,
        UniqueGroupAutoFetch,
        RecordAutoFetch,
        OffTheRecord,
        DontShowCurrencyCode,
        FileTypes
    }

}
