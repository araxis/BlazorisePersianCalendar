using System;

namespace BlazorCalendar
{
    public static class PersianDateUtils
    {
        public static int PersianDayOfWeek(this DayOfWeek start)
        {
            return start switch
            {
                DayOfWeek.Saturday => 0,
                DayOfWeek.Sunday => 1,
                DayOfWeek.Monday => 2,
                DayOfWeek.Tuesday => 3,
                DayOfWeek.Wednesday => 4,
                DayOfWeek.Thursday => 5,
                _ => 6
            };
            // return start == DayOfWeek.Saturday ? 0 : ((int) start) + 1;

        }

        public static int PersianDayOfWeek(this DateTime date)
        {
            return date.DayOfWeek.PersianDayOfWeek();
        }

        public static int PersianStartWeekDay() => 0;
    }
}