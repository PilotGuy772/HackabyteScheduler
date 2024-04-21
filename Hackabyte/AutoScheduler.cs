using System.Runtime.CompilerServices;
using System.Xml;

namespace Hackabyte;

public class AutoScheduler
{
    /*
     * This is the basic implementation for the auto-scheduler
     * - Iterate over assignments in the list based on their priority (higher first)
     * - For any assignment longer than 30 minutes, break it up into 30 minute chunks
     * - Iterate over the continuous free time periods that are available before the due date. Add thirty minute
     *   work times to the beginning of each free work period. After reaching the end of the available work periods,
     *   restart from the beginning. Stop once there are no more work periods. This will ensure that the assignment
     *   is finished before the due date and spaces work out over the time period, but also ensures that work is
     *   front-loaded.
     */

    private static List<BlockTime> FreeTime = new();
    
    public static void ScheduleAssignments()
    {
        //sort assignments by priority
        Assignment.Assignments.Sort(new AssignmentComparator());

        //iterate through assignments in order
        foreach (Assignment assignment in Assignment.Assignments)
        {
            
        }
        
        
    }

    private static void FindFreeTime(DateTime day)
    {
        /*
         * Getting Periods of Free Time
         * There needs to be a way to find periods of free time during the day based on where there are no block times.
         * To do this, iterate through each thirty minute chunk of time between wake-up time (say 6:30) and bedtime (say 9:30).
         * If, during this time chunk, there are any start times or end times of block times or work times, this is not a viable work period.
         * If there is a start time detected, continue iteration at the time chunk after the end time associated with the start time.
         *
         * Every period of work time is saved as a BlockTime object in a list.
         */
        
        //update all recurring items
        foreach (RecurringItem recurringItem in Schedule.RecurringItems)
        {
            recurringItem.Update(day);
        }
        
        DateTime workingStart = new DateTime(day.Year, day.Month, day.Day, 6, 30, 0);
        DateTime workingEnd = new DateTime(day.Year, day.Month, day.Day, 7, 0, 0);
        DateTime end = new DateTime(day.Year, day.Month, day.Day, 21, 30, 0);
        
        while (workingEnd < end)
        {
            // if there are no interfering times,
            if (!Schedule.ScheduleItems.Any(item => item.StartTime > workingStart || item.EndTime < workingEnd))
            {
                // add this free time to the list of times that are free
                FreeTime.Add(new BlockTime() {Name = "Free Time", EndTime = workingEnd, StartTime = workingStart});
            }
            
            //otherwise, there are interfering times so we don't add it.
            //now increment by thirty minutes.
            workingStart = workingStart.AddMinutes(30);
            workingEnd = workingEnd.AddMinutes(30);
        }
    }
}