namespace ShapeTask.Shapes;

public class Rectangle : IShape
{
    private double Width { get; set; }
    private double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double GetWidth()
    {
        return Width;
    }

    public double GetHeight()
    {
        return Height;
    }

    public double GetArea()
    {
        return Width * Height;
    }

    public double GetPerimeter()
    {
        return 2 * (Width + Height);
    }

    public override string ToString()
    {
        return $"Фигура - {nameof(Rectangle)}, ширина - {Width}, высота - {Height}";
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

        Rectangle other = (Rectangle)obj;

        return Math.Abs(Height - other.Height) < double.Epsilon && Math.Abs(Width - other.Width) < double.Epsilon;
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;
        hash = prime * hash + Width.GetHashCode();
        hash = prime * hash + Height.GetHashCode();

        return hash;
    }
}