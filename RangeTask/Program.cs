namespace RangeTask;

public static class Program
{
    public static void Main(string[] args)
    {
        var rangeSource = new Range(2, 10);

        Console.WriteLine($"Исходный диапазон: {rangeSource}");
        Console.WriteLine($"Число {5} принадлежит диапазону: {rangeSource.IsInside(5)}");

        var rangeIntersection = rangeSource.GetIntersection(new Range(5, 12));
        Console.WriteLine($"Диапазона пересечения: {rangeIntersection}");

        var rangesUnion = rangeSource.GetUnion(new Range(5, 12));
        foreach (var range in rangesUnion)
        {
            Console.WriteLine($"Диапазон после объединения: {range}");
        }

        var rangesDifference = rangeSource.GetDifference(new Range(0, 3));
        foreach (var range in rangesDifference)
        {
            Console.WriteLine($"Диапазон после вычитания: {range}");
        }

        Console.Read();
    }
}