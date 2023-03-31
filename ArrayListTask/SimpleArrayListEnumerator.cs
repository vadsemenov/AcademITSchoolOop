using System.Collections;

namespace ArrayListTask;

internal class SimpleArrayListEnumerator<T> : IEnumerator<T>
{
    private readonly T[] _items;
    private readonly int _size;
    private int _position = -1;

    public SimpleArrayListEnumerator(T[] items, int size)
    {
        _items = items;
        _size = size;
    }

    public T Current
    {
        get
        {
            if (_position == -1 || _position >= _size)
            {
                throw new ArgumentException("Позиция перечеслителя вне диапазона!", nameof(_position));
            }

            return _items[_position];
        }
    }

    public bool MoveNext()
    {
        if (_position < _size - 1)
        {
            _position++;
            return true;
        }

        return false;
    }

    public void Reset() => _position = -1;

    public void Dispose()
    {
        // Console.WriteLine("Dispose Enumerator");
    }

    object IEnumerator.Current => Current;
}