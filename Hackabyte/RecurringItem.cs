namespace Hackabyte;

/// <summary>
/// A rule for items that recur over multiple weeks
/// </summary>
public class RecurringItem
{
    public DayOfWeek[] DaysOfWeek { get; set; } = [];
    public DateTime LastDay { get; set; } = new DateTime(3000, 12, 20);
    public BlockTime Event { get; set; }

    /// <summary>
    /// Adds a BlockTime item to the list in Schedule.cs for the requested day according to the configured rules.
    /// </summary>
    /// <param name="day">The day to consider</param>
    public void Update(DateTime day)
    {
        if (day > LastDay)
        {
            return;
        }
        
        //check if the day of the week applies
        if (!DaysOfWeek.Contains(day.DayOfWeek)) return;
        
        //Generate a block time and add it
        BlockTime addEvent = Event;
        int difference = (day - Event.StartTime).Days;
        addEvent.StartTime = addEvent.StartTime.AddDays(difference);
        addEvent.EndTime = addEvent.EndTime.AddDays(difference);

        Schedule.ScheduleItems.Add(addEvent);
    }
}