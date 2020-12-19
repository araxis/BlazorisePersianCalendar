using System;
using Blazorise;

namespace BlazorCalendar
{
    public interface ISpecialDay
    {
        DateTime Date { get; set; }
        Color BackgroundColor { get; set; }
    }
}