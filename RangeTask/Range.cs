namespace RangeTask;

public class Range
{
    public double From { get; set; }

    public double To { get; set; }

    public Range(double from, double to)
    {
        From = from;
        To = to;
    }

    public double GetRangeLength()
    {
        return To - From;
    }

    public bool IsInside(double value)
    {
        return From <= value && value <= To;
    }

    public Range GetRangesIntersect(Range secondRange)
    {
        if (To <= secondRange.From || secondRange.To <= From)
        {
            return null;
        }

        if (From <= secondRange.From && To <= secondRange.To)
        {
            return new Range(secondRange.From, To);
        }

        if (secondRange.From <= From && secondRange.To <= To)
        {
            return new Range(From, secondRange.To);
        }

        if (From <= secondRange.From && secondRange.To <= To)
        {
            return new Range(secondRange.From, secondRange.To);
        }

        if (secondRange.From <= From && To <= secondRange.To)
        {
            return new Range(From, To);
        }

        return null;
    }

    public Range[] GetRangesUnion(Range secondRange)
    {
        if (To < secondRange.From)
        {
            return new Range[]
            {
                this,
                secondRange
            };
        }

        if (secondRange.To < From)
        {
            return new Range[]
            {
                secondRange,
                this
            };
        }

        if (From <= secondRange.From && To <= secondRange.To)
        {
            return new Range[] {new Range(From, secondRange.To)};
        }

        if (secondRange.From <= From && secondRange.To <= To)
        {
            return new Range[] {new Range(secondRange.From, To)};
        }

        if (From <= secondRange.From && secondRange.To <= To)
        {
            return new Range[] {new Range(From, To)};
        }

        if (secondRange.From <= From && To <= secondRange.To)
        {
            return new Range[] {new Range(secondRange.From, secondRange.To)};
        }

        throw new ArgumentException("Неверный диапазон", nameof(secondRange));
    }

    public Range[] GetRangesSubtract(Range secondRange)
    {
        if (To <= secondRange.From || secondRange.To <= From)
        {
            return new Range[]
            {
                this
            };
        }

        if (From < secondRange.From)
        {
            return new Range[]
            {
                new Range(From, secondRange.From)
            };
        }

        if (secondRange.From < From)
        {
            return new Range[]
            {
                new Range( secondRange.To, To)
            };
        }

        if (From < secondRange.From && secondRange.To < To)
        {
            return new Range[]
            {
                new Range(From, secondRange.From),
                new Range(secondRange.To, To),
            };
        }

        if (secondRange.From <= From || To <= secondRange.To)
        {
            return new Range[0];
        }

        throw new ArgumentException("Неверный диапазон", nameof(secondRange));
    }
}