using System.Threading.Channels;
using VectorTask;

namespace MatrixTask;

internal class Program
{
    static void Main(string[] args)
    {
        var array1 = new double[,]
        {
             {2.3, 9.2, 4.6},
             {3.4, 1.5, 3.6},
             {20.8, 6.8, 3.4}
        };

        var array2 = new double[,]
        {
             {1, 20, 3},
             {5, 26, 7},
             {9, 10, 31}
        };

        var array3 = new double[] { 2.3, 9.2, 4.6 };
        var array4 = new double[] { 3.4, 1.5, 3.6 };
        var array5 = new double[] { 20.8, 6.8, 3.4 };

        var vectors = new Vector[]
        {
            new Vector(3),
            new Vector(array5),
            new Vector(3, array4),
            new Vector(array5)
        };

        var matrix1 = new Matrix(3, 3);
        Console.WriteLine("Матрица с нулями 3х3 : " + matrix1);

        var matrix2 = new Matrix(new Matrix(array1));
        Console.WriteLine("Конструктор копирования: " + matrix2);

        var matrix3 = new Matrix(array2);
        Console.WriteLine("Конструктор двумерного массива: " + matrix3);

        var matrix4 = new Matrix(vectors);
        Console.WriteLine("Конструктор из вектора строк: " + matrix4);

        Console.WriteLine("Размер матрицы: " + matrix1.GetRowsAmount() + "х" + matrix1.GetColumnsAmount());

        Console.WriteLine("Получение вектора-строки по индексу: " + matrix4.GetRowByIndex(2));

        matrix4.SetRowByIndex(2, new Vector(array5));
        Console.WriteLine("Задание вектора-строки по индексу: " + matrix4.GetRowByIndex(2));

        Console.WriteLine("Получение вектора-столбца по индексу: " + matrix4.GetColumnByIndex(2));

        matrix4.Transpose();
        Console.WriteLine("Транспонирование матрицы: " + matrix4);

        Console.WriteLine("Умножение на скаляр: " + matrix4.MultiplyByScalar(2));

        Console.WriteLine("Детерминант матрицы: " + matrix3.GetMatrixDeterminant());

        Console.WriteLine("Умножение матрицы на вектор: " + matrix3.MultiplyMatrixByVector(new Vector(array3)));

        Console.WriteLine("Сложение матриц: " + matrix2.AddMatrix(matrix3));

        Console.WriteLine("Вычитание матриц: " + matrix2.SubtractMatrix(matrix3));

        Console.WriteLine("Сложение матриц: " + Matrix.GetMatrixSum(matrix2, matrix3));

        Console.WriteLine("Вычитание матриц: " + Matrix.GetMatrixDifference(matrix2, matrix3));

        Console.WriteLine("Умножение матриц: " + Matrix.GetMatrixProduct(matrix2, matrix3));

        Console.Read();
    }
}