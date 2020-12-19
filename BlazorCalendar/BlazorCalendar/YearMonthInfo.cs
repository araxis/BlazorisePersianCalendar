using System;
using System.Globalization;
using DNTPersianUtils.Core;

namespace BlazorCalendar
{
    public class YearMonthInfo
    {

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public YearMonthInfo(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

    }
}