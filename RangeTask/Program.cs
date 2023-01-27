namespace RangeTask;

public static class Program
{
    public static void Main(string[] args)
    {
        Range range = new Range(2,10);

        Console.WriteLine($"Длина диапазона: {range.GetRangeLength()}");
        Console.WriteLine($"Число {5} принадлежит диапазону: {range.IsInside(5)}");

        Range rangeIntersect = range.GetRangesIntersect(new Range(5, 12));
        Console.WriteLine($"Длина диапазона пересечения: {rangeIntersect.GetRangeLength()}");

        Range[] rangesUnion = range.GetRangesUnion(new Range(5, 12));
        foreach (var rangeUn in rangesUnion)
        {
            Console.WriteLine($"Длина диапазона после объединения: {rangeUn.GetRangeLength()}");
        }

        Range[] rangesSubtract = range.GetRangesSubtract(new Range(0, 3));
        foreach (var rangeSub in rangesSubtract)
        {
            Console.WriteLine($"Длина диапазона после вычитания: {rangeSub.GetRangeLength()}");
        }

        Console.Read();
    }
}