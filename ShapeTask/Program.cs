using ShapeTask.Comparers;
using ShapeTask.Shapes;

namespace ShapeTask;

public class Program
{
    static void Main(string[] args)
    {
        IShape[] shapes =
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
        Console.WriteLine($"Второй по величине периметр фигуры: {secondLargestPerimeterShape.GetPerimeter()}");

        Console.Read();
    }

    private static IShape GetSecondLargestPerimeterShape(IShape[] shapes)
    {
        IShape[] shapesArray = (IShape[])shapes.Clone();
        Array.Sort(shapesArray, new ShapePerimeterComparer());

        return shapesArray[^2];
    }

    private static IShape GetLargestAreaShape(IShape[] shapes)
    {
        IShape[] shapesArray = (IShape[])shapes.Clone();
        Array.Sort(shapesArray, new ShapeAreaComparer());

        return shapesArray[^1];
    }
}