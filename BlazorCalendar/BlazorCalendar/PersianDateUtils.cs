using System;
using DNTPersianUtils.Core;

namespace BlazorCalendar
{
    public static class PersianDateUtils
    {
        public static int PersianDayOfWeek(this DayOfWeek start)
        {
            return start == DayOfWeek.Sunday ? 0 : ((int) start) + 1;

        }

        public static int PersianDayOfWeek(this DateTime date)
        {
            return date.DayOfWeek.PersianDayOfWeek();
        }

        public static int PersianStartWeekDay() => 0;
    }
}