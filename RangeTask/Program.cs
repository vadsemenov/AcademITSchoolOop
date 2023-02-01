namespace RangeTask;

public static class Program
{
    public static void Main(string[] args)
    {
        var rangeSource = new Range(2, 10);

        Console.WriteLine($"Длина диапазона: {rangeSource.GetLength()}");
        Console.WriteLine($"Число {5} принадлежит диапазону: {rangeSource.IsInside(5)}");

        var rangeIntersection = rangeSource.GetRangesIntersection(new Range(5, 12));
        Console.WriteLine($"Диапазона пересечения: {rangeIntersection}");

        var rangesUnion = rangeSource.GetRangesUnion(new Range(5, 12));
        foreach (var range in rangesUnion)
        {
            Console.WriteLine($"Диапазон после объединения: {range}");
        }

        var rangesSubtract = rangeSource.GetRangesDifference(new Range(0, 3));
        foreach (var range in rangesSubtract)
        {
            Console.WriteLine($"Диапазон после вычитания: {range}");
        }

        Console.Read();
    }
}