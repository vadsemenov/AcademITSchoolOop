namespace VectorTask;

public class Vector
{
    private double[] _components;

    public Vector(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Размерность Вектора должна быть больше 0. Текущий размер: " + size,
                nameof(size));
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
            throw new ArgumentException("Размерность массива должна быть больше 0, сейчас равно: " + components.Length,
                nameof(components));
        }

        this._components = (double[])components.Clone();
    }

    public Vector(int size, double[] components)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Размерность должна быть больше 0. Текущее значение равно: " + size);
        }

        int minSize = Math.Min(size, components.Length);

        this._components = new double[minSize];

        Array.Copy(components, this._components, minSize);
    }

    public int GetSize()
    {
        return _components.Length;
    }

    public Vector AddVector(Vector vector)
    {
        if (_components.Length < vector._components.Length)
        {
            var tempComponents = new double[vector._components.Length];

            Array.Copy(_components, tempComponents, _components.Length);

            _components = (double[])tempComponents.Clone();
        }

        for (int i = 0; i < vector._components.Length; i++)
        {
            _components[i] += vector._components[i];
        }

        return this;
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        return new Vector(vector1).AddVector(vector2);
    }

    public Vector SubtractVector(Vector vector)
    {
        if (_components.Length < vector._components.Length)
        {
            var tempComponents = new double[vector._components.Length];

            Array.Copy(_components, tempComponents, _components.Length);

            _components = (double[])tempComponents.Clone();
        }

        for (int i = 0; i < vector._components.Length; i++)
        {
            _components[i] -= vector._components[i];
        }

        return this;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        return new Vector(vector1).SubtractVector(vector2);
    }

    public Vector MultiplyByScalar(double scalar)
    {
        for (int i = 0; i < _components.Length; i++)
        {
            _components[i] *= scalar;
        }

        return this;
    }

    public Vector ReverseVector()
    {
        return MultiplyByScalar(-1);
    }

    public double GetVectorLength()
    {
        double elementsSquaresSum = 0;

        foreach (double component in _components)
        {
            elementsSquaresSum += Math.Abs(component);
        }

        return elementsSquaresSum;
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        double scalarProduct = 0;

        int minVectorSize = Math.Min(vector1._components.Length, vector2._components.Length);

        for (int i = 0; i < minVectorSize; i++)
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

        Vector vector = (Vector)obj;

        return Array.Equals(this._components, vector._components);
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;

        hash = prime * hash + GetArrayHashCode(_components);

        return hash;
    }

    public static int GetArrayHashCode(double[]? array)
    {
        if (array == null)
        {
            return 0;
        }

        int result = 1;

        foreach (double element in array)
        {
            result = 31 * result + element.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        String storageInfo = string.Join(',', _components);

        return "{" + storageInfo + "}";
    }
}