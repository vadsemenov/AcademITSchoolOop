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
}