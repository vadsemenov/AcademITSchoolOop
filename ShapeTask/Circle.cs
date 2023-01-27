namespace ShapeTask;

public class Circle : IShape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }

    public double GetWidth()
    {
        return 2 * _radius;
    }

    public double GetHeight()
    {
        return 2 * _radius;
    }

    public double GetArea()
    {
        return Math.PI * (_radius * _radius);
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * _radius;
    } 

    public override string ToString()
    {
        return $"Фигура - {nameof(Circle)}";
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
        
        Circle other = (Circle)obj;

        return  _radius.CompareTo(other._radius) == 0 ;
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = prime + _radius.GetHashCode();

        return hash;
    }
}