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

    public Range GetRangesIntersection(Range range)
    {
        if (To <= range.From || range.To <= From)
        {
            return null;
        }

        if (From <= range.From && To <= range.To)
        {
            return new Range(range.From, To);
        }

        if (range.From <= From && range.To <= To)
        {
            return new Range(From, range.To);
        }

        if (From <= range.From && range.To <= To)
        {
            return new Range(range.From, range.To);
        }

        if (range.From <= From && To <= range.To)
        {
            return new Range(From, To);
        }

        return null;
    }

    public Range[] GetRangesUnion(Range range)
    {
        if (To < range.From)
        {
            return new Range[]
            {
                (Range) Clone(),
                (Range) range.Clone()
            };
        }

        if (range.To < From)
        {
            return new Range[]
            {
                (Range) range.Clone(),
                (Range) Clone()
            };
        }

        if (From <= range.From && To <= range.To)
        {
            return new Range[] { new Range(From, range.To) };
        }

        if (range.From <= From && range.To <= To)
        {
            return new Range[] { new Range(range.From, To) };
        }

        if (From <= range.From && range.To <= To)
        {
            return new Range[] { new Range(From, To) };
        }

        if (range.From <= From && To <= range.To)
        {
            return new Range[] { new Range(range.From, range.To) };
        }

        throw new ArgumentException("Неверный диапазон", nameof(range));
    }

    public Range[] GetRangesDifference(Range range)
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
        return $"Range From-{From}, To-{To}";
    }
}