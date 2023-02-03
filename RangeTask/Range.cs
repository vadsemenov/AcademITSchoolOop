namespace RangeTask;

public class Range : ICloneable
{
    public double From { get; set; }

    public double To { get; set; }

    public Range(double from, double to)
    {
        From = from;
        To = to;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public double GetLength()
    {
        return To - From;
    }

    public bool IsInside(double value)
    {
        return From <= value && value <= To;
    }

    public Range GetIntersection(Range range)
    {
        if (range.To <= From || range.From >= To)
        {
            return null;
        }

        return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
    }

    public Range[] GetUnion(Range range)
    {
        if (range.To < From || range.From > To)
        {
            return new Range[] { new Range(From, To), new Range(range.From, range.To) };
        }

        return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
    }

    public Range[] GetDifference(Range range)
    {
        if (To <= range.From || range.To <= From)
        {
            return new Range[]
            {
                (Range) Clone()
            };
        }

        if (From < range.From && range.To < To)
        {
            return new Range[]
            {
                new Range(From, range.From),
                new Range(range.To, To),
            };
        }

        if (From < range.From)
        {
            return new Range[] { new Range(From, range.From) };
        }

        if (range.To < To)
        {
            return new Range[] { new Range(range.To, To) };
        }

        return Array.Empty<Range>();
    }

    public override string ToString()
    {
        return $"({From}; {To})";
    }
}