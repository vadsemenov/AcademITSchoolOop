namespace TreeTask
{
    public class Distance : IComparable<Distance>
    {
        public int Length { get; set; }

        public int CompareTo(Distance other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return Length.CompareTo(other.Length);
        }

        public override string ToString()
        {
            return Length.ToString();
        }
    }

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

}