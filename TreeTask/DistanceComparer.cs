namespace TreeTask;

public class DistanceComparer : IComparer<Distance>
{
    public int Compare(Distance x, Distance y)
    {
        if (ReferenceEquals(x, y))
        {
            return 0;
        }

        if (ReferenceEquals(null, y))
        {
            return 1;
        }

        if (ReferenceEquals(null, x))
        {
            return -1;
        }

        return x.Length.CompareTo(y.Length);
    }
}