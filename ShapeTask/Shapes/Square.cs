namespace ShapeTask.Shapes;

public class Square : IShape
{
    public double SideLength { get; }

    public Square(double sideLength)
    {
        SideLength = sideLength;
    }

    public double GetWidth()
    {
        return SideLength;
    }

    public double GetHeight()
    {
        return SideLength;
    }

    public double GetArea()
    {
        return SideLength * SideLength;
    }

    public double GetPerimeter()
    {
        return 4 * SideLength;
    }

    public override string ToString()
    {
        return $"Фигура - {nameof(Square)}, длина стороны - {SideLength}";
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

        Square other = (Square)obj;

        return SideLength == other.SideLength;
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;
        hash = prime * hash + SideLength.GetHashCode();

        return hash;
    }
}