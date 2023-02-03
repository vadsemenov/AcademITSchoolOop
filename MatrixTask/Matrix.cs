using VectorTask;

namespace MatrixTask;

public class Matrix
{
    private Vector[] _rows;

    public Matrix(int rowsAmount, int columnsAmount)
    {
        _rows = new Vector[rowsAmount];

        for (int i = 0; i < rowsAmount; i++)
        {
            _rows[i] = new Vector(columnsAmount);
        }
    }

    public Matrix(Matrix matrix) : this(matrix._rows)
    {
    }

    public Matrix(double[,] arrays)
    {
        int arrayRowsAmount = arrays.GetLength(0);
        int arrayColumnsAmount = arrays.GetLength(1);

        this._rows = new Vector[arrayRowsAmount];

        for (int i = 0; i < arrayColumnsAmount; i++)
        {
            double[] arrayComponents = new double[arrays.GetLength(1)];

            for (int j = 0; j < arrayColumnsAmount; j++)
            {
                arrayComponents[j] = arrays[i, j];
            }

            this._rows[i] = new Vector(arrayComponents);
        }
    }

    public Matrix(Vector[] vectors)
    {
        this._rows = vectors;
    }

    public int GetRowsAmount()
    {
        return _rows.Length;
    }

    public int GetColumnsAmount()
    {
        return _rows[0].GetSize();
    }

    public Vector GetRowByIndex(int index)
    {
        int rowsAmount = GetRowsAmount();

        if (index < 0 || index >= rowsAmount)
        {
            throw new IndexOutOfRangeException("Индекс должен быть больше или равен 0 и меньше " + rowsAmount
                + " Текущее значение: " + index);
        }

        return new Vector(_rows[index]);
    }

    public void SetRowByIndex(int index, Vector row)
    {
        int rowsAmount = GetRowsAmount();

        if (index < 0 || index >= rowsAmount)
        {
            throw new IndexOutOfRangeException("Индекс должен быть больше или равен 0 и меньше " + rowsAmount
                + " Текущее значение: " + index);
        }

        int columnsAmount = GetColumnsAmount();
        int rowSize = row.GetSize();

        if (rowSize != columnsAmount)
        {
            throw new ArgumentException("Размер переданного вектора должен быть равен " + columnsAmount
                + ". Текущий размер вектора: " + rowSize);
        }

        _rows[index] = new Vector(row);
    }

    public Vector GetColumnByIndex(int index)
    {
        int columnsCount = GetColumnsAmount();

        if (index < 0 || index >= columnsCount)
        {
            throw new IndexOutOfRangeException("Индекс должен быть больше или равен 0 и меньше " + columnsCount
                + " Текущее значение: " + index);
        }

        int rowsCount = GetRowsAmount();
        Vector column = new Vector(rowsCount);

        for (int i = 0; i < rowsCount; i++)
        {
            column.SetComponentByIndex(i, _rows[i].GetComponentByIndex(index));
        }

        return column;
    }

    public void Transpose()
    {
        Vector[] transposedMatrixRows = new Vector[GetColumnsAmount()];

        for (int i = 0; i < transposedMatrixRows.Length; i++)
        {
            transposedMatrixRows[i] = GetColumnByIndex(i);// ---
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
}