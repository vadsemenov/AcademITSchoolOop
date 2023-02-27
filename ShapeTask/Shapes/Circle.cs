namespace ShapeTask.Shapes;

public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetWidth()
    {
        return 2 * Radius;
    }

    public double GetHeight()
    {
        return 2 * Radius;
    }

    public double GetArea()
    {
        return Math.PI * (Radius * Radius);
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override string ToString()
    {
        return $"Фигура - {nameof(Circle)}, радиус - {Radius}";
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

        Circle other = (Circle)obj;

        return Radius == other.Radius;
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = prime + Radius.GetHashCode();

        return hash;
    }
}