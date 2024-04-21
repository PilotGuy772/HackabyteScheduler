namespace Hackabyte;

/// <summary>
/// An item in the schedule.
/// </summary>
public abstract class ScheduleItem
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public TimeSpan Duration => EndTime - StartTime;
    public string Name { get; set; } = "";
}