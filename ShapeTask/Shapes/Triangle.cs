namespace ShapeTask.Shapes;

public class Triangle : IShape
{
    private double X1 { get; set; }
    private double Y1 { get; set; }
    private double X2 { get; set; }
    private double Y2 { get; set; }
    private double X3 { get; set; }
    private double Y3 { get; set; }

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
        X3 = x3;
        Y3 = y3;
    }

    public double GetWidth()
    {
        return GetMax(X1, X2, X3) - GetMin(X1, X2, X3);
    }

    public double GetHeight()
    {
        return GetMax(Y1, Y2, Y3) - GetMin(Y1, Y2, Y3);
    }

    public double GetArea()
    {
        return 0.5 * Math.Abs((X2 - X1) * (Y3 - Y1) - (X3 - X1) * (Y2 - Y1));
    }

    public double GetPerimeter()
    {
        return GetDistance(X1, Y1, X2, Y2) +
               GetDistance(X2, Y2, X3, Y3) +
               GetDistance(X3, Y3, X1, Y1);
    }

    private static double GetDistance(double point1X, double point1Y, double point2X, double point2Y)
    {
        return Math.Sqrt(Math.Pow(point1X - point2X, 2) + Math.Pow(point1Y - point2Y, 2));
    }

    private static double GetMin(double value1, double value2, double value3)
    {
        double minValue = value1;

        if (minValue > value2)
        {
            minValue = value2;
        }

        if (minValue > value3)
        {
            minValue = value3;
        }

        return minValue;
    }

    private static double GetMax(double value1, double value2, double value3)
    {
        double max = value1;

        if (max < value2)
        {
            max = value2;
        }

        if (max < value3)
        {
            max = value3;
        }

        return max;
    }

    public override string ToString()
    {
        return $"Фигура - {nameof(Triangle)}, x1 - {X1}, y1 - {Y1}, x2 - {X2}, y2 - {Y2}, x3 - {X3}, y3 - {Y3}";
    }

    public override bool Equals(object obj)
    {
        if (obj == this)
        {
            return true;
        }

        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        Triangle other = (Triangle) obj;

        return Math.Abs(X1 - other.X1) < double.Epsilon &&
               Math.Abs(X2 - other.X2) < double.Epsilon &&
               Math.Abs(X3 - other.X3) < double.Epsilon &&
               Math.Abs(Y1 - other.Y1) < double.Epsilon &&
               Math.Abs(Y2 - other.Y2) < double.Epsilon &&
               Math.Abs(Y2 - other.Y2) < double.Epsilon;
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;
        hash = prime * hash + X1.GetHashCode();
        hash = prime * hash + X2.GetHashCode();
        hash = prime * hash + X3.GetHashCode();
        hash = prime * hash + Y1.GetHashCode();
        hash = prime * hash + Y2.GetHashCode();
        hash = prime * hash + Y3.GetHashCode();

        return hash;
    }
}