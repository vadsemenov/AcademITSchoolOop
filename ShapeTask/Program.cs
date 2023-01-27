namespace ShapeTask;

public class Program
{
    static void Main(string[] args)
    {
        IShape[] shapes = new IShape[]
        {
            new Circle(10),
            new Rectangle(10, 20),
            new Square(5),
            new Triangle(0, 0, 10, 10, 20, 5),
            new Circle(3),
            new Rectangle(5, 20),
            new Square(7),
            new Triangle(0, 0, 10, 5, 20, 0)
        };

        IShape largestAreaShape = GetLargestAreaShape(shapes);
        Console.WriteLine($"Наибольшая площадь фигуры: {largestAreaShape.GetArea()}");

        IShape secondLargestPerimeterShape = GetSecondLargestPerimeterShape(shapes);
        Console.WriteLine($"Второй по величине периметер фигуры: {secondLargestPerimeterShape.GetPerimeter()}");

        Console.Read();
    }

    private static IShape GetSecondLargestPerimeterShape(IShape[] shapes)
    {
        IShape[] shapesArray = shapes.Clone() as IShape[];
        Array.Sort(shapesArray, new ShapePerimeterComparer());

        return shapesArray[shapesArray.Length - 2];
    }

    private static IShape GetLargestAreaShape(IShape[] shapes)
    {
        IShape[] shapesArray = shapes.Clone() as IShape[];
        Array.Sort(shapesArray, new ShapeAreaComparer());

        return shapesArray[shapesArray.Length - 1];
    }
}

public class ShapeAreaComparer : IComparer<IShape>
{
    public int Compare(IShape x, IShape y)
    {
        return x.GetArea().CompareTo(y.GetArea());
    }
}

public class ShapePerimeterComparer : IComparer<IShape>
{
    public int Compare(IShape x, IShape y)
    {
        return x.GetPerimeter().CompareTo(y.GetPerimeter());
    }
}