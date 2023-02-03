using System.Text;

namespace VectorTask;

public class Vector
{
    private double[] _components;

    public Vector(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Размерность Вектора должна быть больше 0. Текущий размер: " + size, nameof(size));
        }

        _components = new double[size];
    }

    public Vector(Vector vector) : this(vector._components)
    {
    }

    public Vector(double[] components)
    {
        if (components == null)
        {
            throw new ArgumentNullException(nameof(components), "Массив должен быть проинициализирован.");
        }

        if (components.Length == 0)
        {
            throw new ArgumentException("Размерность массива должна быть больше 0, сейчас равно: " + components.Length, nameof(components));
        }

        _components = (double[])components.Clone();
    }

    public Vector(int size, double[] components)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Размерность должна быть больше 0. Текущее значение равно: " + size, nameof(components));
        }

        var minSize = Math.Min(size, components.Length);

        _components = new double[minSize];

        Array.Copy(components, _components, minSize);
    }

    public int GetSize()
    {
        return _components.Length;
    }

    public Vector Add(Vector vector)
    {
        if (_components.Length < vector._components.Length)
        {
            Array.Resize(ref _components, vector._components.Length);
        }

        for (var i = 0; i < vector._components.Length; i++)
        {
            _components[i] += vector._components[i];
        }

        return this;
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        return new Vector(vector1).Add(vector2);
    }

    public Vector Subtract(Vector vector)
    {
        if (_components.Length < vector._components.Length)
        {
            Array.Resize(ref _components, vector._components.Length);
        }

        for (int i = 0; i < vector._components.Length; i++)
        {
            _components[i] -= vector._components[i];
        }

        return this;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        return new Vector(vector1).Subtract(vector2);
    }

    public Vector MultiplyByScalar(double scalar)
    {
        for (var i = 0; i < _components.Length; i++)
        {
            _components[i] *= scalar;
        }

        return this;
    }

    public Vector Reverse()
    {
        return MultiplyByScalar(-1);
    }

    public double GetLength()
    {
        var componentsSquaresSum = 0.0;

        foreach (var component in _components)
        {
            componentsSquaresSum += component * component;
        }

        return Math.Sqrt(componentsSquaresSum);
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        var scalarProduct = 0.0;

        var minVectorSize = Math.Min(vector1._components.Length, vector2._components.Length);

        for (var i = 0; i < minVectorSize; i++)
        {
            scalarProduct += vector1._components[i] * vector2._components[i];
        }

        return scalarProduct;
    }

    public double GetComponentByIndex(int index)
    {
        return _components[index];
    }

    public void SetComponentByIndex(int index, double element)
    {
        _components[index] = element;
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

        var vector = (Vector)obj;

        return ArraysEquals(_components, vector._components);
    }

    private bool ArraysEquals(double[] first, double[] second)
    {
        if (first == null || second == null)
        {
            return false;
        }

        if (first.Length != second.Length)
        {
            return false;
        }

        for (var i = 0; i < first.Length; i++)
        {
            if (Math.Abs(first[i] - second[i]) > double.Epsilon)
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        var prime = 37;
        var hash = 1;

        hash = prime * hash + GetArrayHashCode(_components);

        return hash;
    }

    private static int GetArrayHashCode(double[] array)
    {
        if (array == null)
        {
            return 0;
        }

        int result = 1;

        foreach (var element in array)
        {
            result = 31 * result + element.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append('{');
        stringBuilder.Append(string.Join(", ", _components));
        stringBuilder.Append('}');

        return stringBuilder.ToString();
    }
}