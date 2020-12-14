namespace BlazorCalendar
{
    public interface IWeekNameResolver
    {
        public string[] ShortNames();
        public string[] FullNames();
    }
}