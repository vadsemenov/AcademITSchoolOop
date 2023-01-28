namespace VectorTask;

public class Program
{
    public static void Main(string[] args)
    {
        Vector vector1 = new Vector(4);
        double[] components = { 13.5, 9.3, 3.6, 8.9, 25.7, 33.0 };
        Vector vector2 = new Vector(components);
        Vector vector3 = new Vector(5, components);
        Vector vector4 = new Vector(vector3);

        Console.WriteLine("Размер вектора 1: " + vector1.GetSize());
        Console.WriteLine("Длина вектора 1: " + vector1.GetVectorLength());
        Console.WriteLine("Размер вектора 2: " + vector2.GetSize());
        Console.WriteLine("Длина вектора 2: " + vector2.GetVectorLength());
        Console.WriteLine("Размер вектора 3: " + vector3.GetSize());
        Console.WriteLine("Длина вектора 3: " + vector3.GetVectorLength());
        Console.WriteLine("Размер вектора 4: " + vector4.GetSize());
        Console.WriteLine("Длина вектора 4: " + vector4.GetVectorLength());

        vector3.AddVector(vector4);
        Console.WriteLine("Вектор 3 после прибавления вектора 4: " + vector3);
        Console.WriteLine("Размер вектора 3 после прибавления вектора 4: " + vector2.GetSize());
        Console.WriteLine("Длина вектора 3 после прибавления вектора 4: " + vector2.GetVectorLength());

        vector3.SubtractVector(vector2);
        Console.WriteLine("Вектор 3 после вычитания вектора 2: " + vector2);
        Console.WriteLine("Вектор 3 компонент по индексу 1: " + vector2.GetComponentByIndex(1));

        vector3.SetComponentByIndex(3, 14.0);
        Console.WriteLine("Присвоить компоненту по индексу2 значение 14: " + vector3);

        Vector sumVector = Vector.GetSum(vector3, vector4);
        Console.WriteLine("Сложение вектора 3 и 4: " + sumVector);

        Vector differenceVector = Vector.GetDifference(vector3, vector4);
        Console.WriteLine("Вычитание векторов 3 и 4: " + differenceVector);

        vector4.MultiplyByScalar(10.0);
        Console.WriteLine("Умножение вектора 4 на скаляр 10:" + vector4);

        Console.WriteLine("Разворот вектора 3: " + vector3.ReverseVector());

        double scalarProductVector = Vector.GetScalarProduct(vector2, vector3);
        Console.WriteLine("Скалярное произведение вектора 2 и 3: " + scalarProductVector);

        Console.Read();
    }
}