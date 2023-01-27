namespace ShapeTask;

public class Triangle : IShape
{
    private readonly double _x1;
    private readonly double _y1;
    private readonly double _x2;
    private readonly double _y2;
    private readonly double _x3;
    private readonly double _y3;

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        this._x1 = x1;
        this._y1 = y1;
        this._x2 = x2;
        this._y2 = y2;
        this._x3 = x3;
        this._y3 = y3;
    }

    public double GetWidth()
    {
        return GetMax(_x1, _x2, _x3) - GetMin(_x1, _x2, _x3);
    }

    public double GetHeight()
    {
        return GetMax(_y1, _y2, _y3) - GetMin(_y1, _y2, _y3);
    }

    public double GetArea()
    {
        return 0.5 * Math.Abs((_x2 - _x1) * (_y3 - _y1) - (_x3 - _x1) * (_y2 - _y1));
    }

    public double GetPerimeter()
    {
        return GetDistance(_x1, _y1, _x2, _y2) +
               GetDistance(_x2, _y2, _x3, _y3) +
               GetDistance(_x3, _y3, _x1, _y1);
    }

    private double GetDistance(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
    {
        return Math.Sqrt(Math.Pow((firstPointX - secondPointX), 2) + Math.Pow((firstPointY - secondPointY), 2));
    }

    private double GetMin(double value1, double value2, double value3)
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

    private double GetMax(double value1, double value2, double value3)
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
        return $"Фигура - {nameof(Triangle)}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == this)
        {
            return true;
        }

        if (obj == null || obj.GetType() != this.GetType())
        {
            return false;
        }

        Triangle other = (Triangle) obj;

        return _x1.CompareTo(other._x1) == 0 &&
               _x2.CompareTo(other._x2) == 0 &&
               _x3.CompareTo(other._x3) == 0 &&
               _y1.CompareTo(other._y1) == 0 &&
               _y2.CompareTo(other._y2) == 0 &&
               _y2.CompareTo(other._y2) == 0;
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;
        hash = prime * hash + _x1.GetHashCode();
        hash = prime * hash + _x2.GetHashCode();
        hash = prime * hash + _x3.GetHashCode();
        hash = prime * hash + _y1.GetHashCode();
        hash = prime * hash + _y2.GetHashCode();
        hash = prime * hash + _y3.GetHashCode();

        return hash;
    }
}