namespace Hackabyte;

public class AssignmentComparator : IComparer<Assignment>
{
    public int Compare(Assignment x, Assignment y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        return x.Priority.CompareTo(y.Priority);
    }
}