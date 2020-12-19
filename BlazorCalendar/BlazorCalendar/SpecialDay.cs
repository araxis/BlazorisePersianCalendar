using System;
using Blazorise;

namespace BlazorCalendar
{
    public class SpecialDay : ISpecialDay
    {
        public DateTime Date { get; set; }=DateTime.Now;
        public Color BackgroundColor { get; set; } = Color.None;
        public string Tag { get; set; } = string.Empty;

        public SpecialDay()
        {
            
        }
        public SpecialDay(DateTime date, Color backgroundColor, string tag)
        {
            Date = date;
            BackgroundColor = backgroundColor;
            Tag = tag;
        }
    }
}