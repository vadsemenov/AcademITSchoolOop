namespace ShapeTask;

public class Rectangle : IShape
{
    private readonly double _width;
    private readonly double _height;

    public Rectangle(double height, double width)
    {
        _width = width;
        _height = height;
    }

    public double GetWidth()
    {
        return _width;
    }

    public double GetHeight()
    {
        return _height;
    }

    public double GetArea()
    {
        return _width * _height;
    }

    public double GetPerimeter()
    {
        return 2 * (_width + _height);
    }

    public override string ToString()
    {
        return $"Фигура - {nameof(Rectangle)}";
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

        Rectangle other = (Rectangle) obj;

        return _height.CompareTo(other._height) == 0 &&
               _width.CompareTo(other._width) == 0;
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;
        hash = prime * hash + _width.GetHashCode();
        hash = prime * hash + _height.GetHashCode();

        return hash;
    }
}