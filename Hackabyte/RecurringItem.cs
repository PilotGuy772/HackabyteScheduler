namespace Hackabyte;

/// <summary>
/// A rule for items that recur over multiple weeks
/// </summary>
public class RecurringItem
{
    public DayOfWeek[] DaysOfWeek { get; set; } = [];
    public DateTime LastDay { get; set; }
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
        
        
        
    }
}