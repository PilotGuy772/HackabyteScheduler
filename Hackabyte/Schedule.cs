namespace Hackabyte;

public static class Schedule
{
    /// <summary>
    /// All of the registered schedule items.
    /// </summary>
    public static List<ScheduleItem> ScheduleItems { get; set; } = new();

    public static List<RecurringItem> RecurringItems { get; set; } = new();
}