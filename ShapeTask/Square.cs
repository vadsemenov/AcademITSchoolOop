namespace ShapeTask;

public class Square : IShape
{
    private readonly double _sideLength;

    public Square(double sideLength)
    {
        this._sideLength = sideLength;
    }

    public double GetWidth()
    {
        return _sideLength;
    }

    public double GetHeight()
    {
        return _sideLength;
    }

    public double GetArea()
    {
        return _sideLength * _sideLength;
    }

    public double GetPerimeter()
    {
        return 4 * _sideLength;
    }

    public override string ToString()
    {
        return $"Фигура - {nameof(Square)}";
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

        Square other = (Square)obj;

        return _sideLength.CompareTo(other._sideLength) == 0;
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;
        hash = prime * hash + _sideLength.GetHashCode();
        // hash = prime * hash + (c!= null? c.GetHashCode():0);

        return hash;
    }
}