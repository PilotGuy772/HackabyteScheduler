namespace Hackabyte;

public class Assignment
{
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    public TimeSpan TimeEstimate { get; set; }

    public double Priority =>
        // total amount of time of work needed over total amount of work time until due
        TimeEstimate / (DueDate - DateTime.Now);

    public static List<Assignment> Assignments = [];
    
}