// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorCalendar
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Projects\Components\BlazorCalendar\BlazorCalendar\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\Components\BlazorCalendar\BlazorCalendar\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Projects\Components\BlazorCalendar\BlazorCalendar\PCalender.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\Components\BlazorCalendar\BlazorCalendar\PCalender.razor"
using DNTPersianUtils.Core;

#line default
#line hidden
#nullable disable
    public partial class PCalender : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 109 "C:\Projects\Components\BlazorCalendar\BlazorCalendar\PCalender.razor"
       

    readonly IEnumerable<string> _weekDayNames = new List<string> { "ش", "ی", "د", "س", "چ", "پ", "ج" };
    List<DateTime> _days = new();


    int _year;
    int _pMonth;

    [Parameter]
    public DateTime Date { get; set; } = DateTime.Now;

    [Parameter]
    public IEnumerable<SpecialDay> SpecialDays { get; set; } = new List<SpecialDay>();

    [Parameter]
    public bool RenderSelectedDate { get; set; } = true;

    [Parameter]
    public bool RenderToday { get; set; } = true;


    [Parameter]
    public EventCallback<DateTime> DateChanged { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        var pc = new PersianCalendar();
        var month= pc.GetMonth(Date);
        var year = pc.GetYear(Date);

        var days= pc.GetDaysInMonth(year, month);
        var date = pc.ToDateTime(year, month, 1, 0, 0, 0,0);


        _year=date.GetPersianYear();
        _pMonth = date.GetPersianMonth();
        var startWeekDay = PersianDayOfWeek(date);
        date = pc.AddDays(date,-startWeekDay);

        for (var i = 0; i < days; i++)
        {
            _days.Add(pc.AddDays(date,i));
        }

    }

    void OnNext()
    {
        AddMonth(1);
    }

    int PersianDayOfWeek( DayOfWeek start)
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

    int PersianDayOfWeek( DateTime date)
    {
        return date.DayOfWeek.PersianDayOfWeek();
    }


    private void OnPrev()
    {
        AddMonth(-1);
    }

    private void AddMonth(int monthCount)
    {
        var pc = new PersianCalendar();
        var date = pc.ToDateTime(_year, _pMonth, 1, 0, 0, 0,0);
        date = pc.AddMonths(date, monthCount);

        _year =date.GetPersianYear();
        _pMonth = date.GetPersianMonth();
        var days = pc.GetDaysInMonth(_year, _pMonth);
        var startWeekDay = PersianDayOfWeek(date);
        date = pc.AddDays(date,-startWeekDay);
        _days.Clear();
        for (var i = 0; i < days; i++)
        {
            _days.Add(pc.AddDays(date,i));
        }
    }

    private async Task DateSelected(DateTime item)
    {
        await DateChanged.InvokeAsync(item);
    }




    private string GetItemClass(DateTime item)
    {
        var selectedCss = RenderSelectedDate && item.DayOfYear == Date.DayOfYear ? "border border-primary" : "";
        var specialDay = SpecialDays.FirstOrDefault(d => d.Date.DayOfYear == item.DayOfYear);

        if (specialDay != null)
        {
            var bg= specialDay.BackgroundColor switch {
                Color.Link => "bg-white",
                Color.None => "bg-transparent",
                Color.Primary => "bg-primary",
                Color.Secondary => "bg-secondary",
                Color.Success => "bg-success",
                Color.Danger => "bg-danger",
                Color.Warning => "bg-warning",
                Color.Info => "bg-info",
                Color.Light => "bg-light",
                Color.Dark => "bg-dark",
                _ => throw new ArgumentOutOfRangeException()};

            return $"text-center {bg} {selectedCss}";
        }

        var today= RenderToday && item.DayOfYear == DateTime.Now.DayOfYear ? "today" : "";

        return $"text-center {today} {selectedCss}";


    }

    private bool CanShow(DateTime date)
    {
        var pc = new PersianCalendar();
        var month = pc.GetMonth(date);
        return month == _pMonth;

    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
