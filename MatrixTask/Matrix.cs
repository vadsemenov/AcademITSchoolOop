using System.Text;
using VectorTask;

namespace MatrixTask;

public class Matrix
{
    private Vector[] _rows;

    public Matrix(int rowsAmount, int columnsAmount)
    {
        if (rowsAmount <= 0)
        {
            throw new ArgumentException("Количество строк матрицы должны быть больше 0. Переданное количество: "
                                        + rowsAmount, nameof(rowsAmount));
        }

        if (columnsAmount <= 0)
        {
            throw new ArgumentException("Количество столбцов матрицы должны быть больше 0. Переданное количество: "
                                        + columnsAmount, nameof(columnsAmount));
        }

        _rows = new Vector[rowsAmount];

        for (var i = 0; i < rowsAmount; i++)
        {
            _rows[i] = new Vector(columnsAmount);
        }
    }

    public Matrix(Matrix matrix) : this(matrix._rows)
    {
    }

    public Matrix(double[,] array)
    {
        var arrayRowsAmount = array.GetLength(0);
        var arrayColumnsAmount = array.GetLength(1);

        if (arrayRowsAmount == 0)
        {
            throw new ArgumentException("Количество строк двумерного массива должно быть больше 0", nameof(array));
        }

        if (arrayColumnsAmount == 0)
        {
            throw new ArgumentException("Количество столбцов двумерного массива должно быть больше 0", nameof(array));
        }

        _rows = new Vector[arrayRowsAmount];

        var arrayRow = new double[arrayColumnsAmount];

        for (var i = 0; i < arrayRowsAmount; i++)
        {
            for (var j = 0; j < arrayColumnsAmount; j++)
            {
                arrayRow[j] = array[i, j];
            }

            _rows[i] = new Vector(arrayRow);
        }
    }

    public Matrix(Vector[] vectors)
    {
        if (vectors.Length == 0)
        {
            throw new ArgumentException("Размер массива векторов должен быть больше 0", nameof(vectors));
        }

        var vectorsMaxSize = vectors.Max(l => l.GetSize());

        _rows = new Vector[vectors.Length];

        for (var i = 0; i < _rows.Length; i++)
        {
            _rows[i] = new Vector(vectorsMaxSize, vectors[i].GetComponents());
        }
    }

    public int GetRowsAmount => _rows.Length;

    public int GetColumnsAmount => _rows[0].GetSize();

    public Vector GetRowByIndex(int index)
    {
        if (index < 0 || index >= _rows.Length)
        {
            throw new IndexOutOfRangeException("Индекс должен быть больше или равен 0 и меньше " + _rows.Length
                + ". Текущее значение: " + index);
        }

        return new Vector(_rows[index]);
    }

    public void SetRowByIndex(int index, Vector row)
    {
        if (index < 0 || index >= _rows.Length)
        {
            throw new IndexOutOfRangeException("Индекс должен быть больше или равен 0 и меньше " + _rows.Length
                + ". Текущее значение: " + index);
        }

        var currentRowSize = GetColumnsAmount;
        var rowSize = row.GetSize();

        if (rowSize != currentRowSize)
        {
            throw new ArgumentException("Размер переданного вектора должен быть равен " + currentRowSize
                + ". Текущий размер вектора: " + rowSize, nameof(row));
        }

        _rows[index] = new Vector(row);
    }

    public Vector GetColumnByIndex(int index)
    {
        var columnsAmount = GetColumnsAmount;

        if (index < 0 || index >= columnsAmount)
        {
            throw new IndexOutOfRangeException("Индекс должен быть больше или равен 0 и меньше " + columnsAmount
                + ". Текущее значение: " + index);
        }

        var column = new Vector(_rows.Length);

        for (var i = 0; i < _rows.Length; i++)
        {
            column.SetComponentByIndex(i, _rows[i].GetComponentByIndex(index));
        }

        return column;
    }

    public void Transpose()
    {
        var transposedMatrixRows = new Vector[_rows[0].GetSize()];

        for (var i = 0; i < transposedMatrixRows.Length; i++)
        {
            transposedMatrixRows[i] = GetColumnByIndex(i); // ---
        }

        _rows = transposedMatrixRows;
    }

    public Matrix MultiplyByScalar(double scalar)
    {
        foreach (var row in _rows)
        {
            row.MultiplyByScalar(scalar);
        }

        return this;
    }

    public double GetDeterminant()
    {
        var columnsAmount = GetColumnsAmount;
        var rowsAmount = _rows.Length;

        if (rowsAmount != columnsAmount)
        {
            throw new InvalidOperationException("Количество строк должно быть равно количеству столбцов. Размеры матрицы:"
                                               + rowsAmount + " на " + columnsAmount);
        }

        if (rowsAmount == 1)
        {
            return _rows[0].GetComponentByIndex(0);
        }

        var determinant = 0.0;

        for (var i = 0; i < rowsAmount; i++)
        {
            determinant += Math.Pow(-1, i) * _rows[i].GetComponentByIndex(0) * GetMinor(this, i);
        }

        return determinant;
    }

    private static double GetMinor(Matrix matrix, int rowIndex)
    {
        var size = matrix._rows.Length - 1;
        var resultMatrix = new Matrix(size, size);

        for (int i = 0, resultMatrixI = 0; i <= size; i++)
        {
            for (int j = 0, resultMatrixJ = 0; j <= size; j++)
            {
                if (i != rowIndex && j != 0)
                {
                    resultMatrix._rows[resultMatrixI]
                        .SetComponentByIndex(resultMatrixJ, matrix._rows[i].GetComponentByIndex(j));

                    resultMatrixJ++;

                    if (resultMatrixJ == size)
                    {
                        resultMatrixJ = 0;
                        resultMatrixI++;
                    }
                }
            }
        }

        return resultMatrix.GetDeterminant();
    }

    public Vector Multiply(Vector vector)
    {
        var columnsAmount = GetColumnsAmount;
        var vectorSize = vector.GetSize();

        if (columnsAmount != vectorSize)
        {
            throw new ArgumentException(
                "Количество столбцов матрицы должно быть равно размеру вектора. Количество столбцов: "
                + columnsAmount + ". Размер вектора: " + vectorSize, nameof(vector));
        }

        var resultVector = new Vector(_rows.Length);

        for (var i = 0; i < _rows.Length; i++)
        {
            var resultVectorComponent = Vector.GetScalarProduct(_rows[i], vector);

            resultVector.SetComponentByIndex(i, resultVectorComponent);
        }

        return resultVector;
    }

    public Matrix Add(Matrix matrix)
    {
        CheckMatrixesSizes(this, matrix);

        for (var i = 0; i < _rows.Length; i++)
        {
            _rows[i].Add(matrix._rows[i]);
        }

        return this;
    }

    public Matrix Subtract(Matrix matrix)
    {
        CheckMatrixesSizes(this, matrix);

        for (var i = 0; i < _rows.Length; i++)
        {
            _rows[i].Subtract(matrix._rows[i]);
        }

        return this;
    }

    private static void CheckMatrixesSizes(Matrix matrix1, Matrix matrix2)
    {
        var matrix1ColumnsAmount = matrix1.GetColumnsAmount;
        var matrix1RowsAmount = matrix1._rows.Length;
        var matrix2ColumnsAmount = matrix2.GetColumnsAmount;
        var matrix2RowsAmount = matrix2._rows.Length;

        if (matrix1RowsAmount != matrix2RowsAmount || matrix1ColumnsAmount != matrix2ColumnsAmount)
        {
            throw new ArgumentException("Матрицы должны иметь одинаковые размеры. Размер первой матрицы: "
                                        + matrix1RowsAmount + " на " + matrix1ColumnsAmount + " Размер второй матрицы: "
                                        + matrix2RowsAmount + " на " + matrix2ColumnsAmount);
        }
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        CheckMatrixesSizes(matrix1, matrix2);

        return new Matrix(matrix1).Add(matrix2);
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        CheckMatrixesSizes(matrix1, matrix2);

        return new Matrix(matrix1).Subtract(matrix2);
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        var matrix1ColumnsAmount = matrix1.GetColumnsAmount;
        var matrix2RowsAmount = matrix2._rows.Length;

        if (matrix1ColumnsAmount != matrix2RowsAmount)
        {
            throw new ArgumentException(
                "Количество столбцов первой матрицы и количество строк второй матрицы должны быть равны. " +
                "Количество столбцов первой матрицы: " + matrix1ColumnsAmount +
                " Количество строк второй матрицы: " + matrix2RowsAmount, nameof(matrix1) + " " + nameof(matrix2));
        }

        var matrix1RowsAmount = matrix1._rows.Length;
        var matrix2ColumnsAmount = matrix2.GetColumnsAmount;

        var resultRows = new double[matrix1RowsAmount, matrix2ColumnsAmount];

        for (int i = 0; i < matrix1RowsAmount; i++)
        {
            for (int j = 0; j < matrix2ColumnsAmount; j++)
            {
                resultRows[i, j] = Vector.GetScalarProduct(matrix1._rows[i], matrix2.GetColumnByIndex(j));
            }
        }

        return new Matrix(resultRows);
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append('{');
        stringBuilder.AppendJoin<Vector>(", ", _rows);
        stringBuilder.Append('}');

        return stringBuilder.ToString();
    }
}