using System.Collections;

namespace ArrayListTask;

public class SimpleArrayList<T> : IList<T>
{
    private const int DefaultCapacity = 4;
    private T[] _items;
    private int _size;

    public SimpleArrayList() => _items = new T[DefaultCapacity];

    public SimpleArrayList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity),
                "Вместимость должна быть более или равна нулю!");
        }

        _items = new T[capacity];
    }

    public bool IsReadOnly { get; }

    public int Capacity
    {
        get => _items.Length;
        set
        {
            if (value < _size)
            {
                throw new ArgumentOutOfRangeException(nameof(_size), "Вместимость меньше существующей!");
            }

            if (value == _items.Length)
            {
                return;
            }

            if (value > 0)
            {
                var destinationArray = new T[value];

                if (_size > 0)
                {
                    Array.Copy(_items, 0, destinationArray, 0, _size);
                }

                _items = destinationArray;
            }
            else
            {
                _items = Array.Empty<T>();
            }
        }
    }

    private void EnsureCapacity(int min)
    {
        if (_items.Length >= min)
        {
            return;
        }

        int num = _items.Length == 0 ? 4 : _items.Length * 2;

        if ((uint)num > 2146435071U)
        {
            num = 2146435071;
        }

        if (num < min)
        {
            num = min;
        }

        Capacity = num;
    }

    public void TrimExcess()
    {
        if (_size >= (int)(_items.Length * 0.9))
        {
            return;
        }

        Capacity = _size;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне границ списка!");
            }

            return _items[index];
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне границ списка!");
            }

            _items[index] = value;
        }
    }

    public int Count
    {
        get => _size;
    }

    public void Add(T item)
    {
        if (_size == _items.Length)
        {
            EnsureCapacity(_size + 1);
        }

        _items[_size++] = item;
    }

    public void Clear()
    {
        _items = new T[DefaultCapacity];
        _size = 0;
    }

    public bool Contains(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Аргумент равен null");
        }

        return IndexOf(item) != -1;
    }

    public void CopyTo(T[] array, int arrayIndex) => Array.Copy(_items, 0, array, arrayIndex, _size);

    public bool Remove(T item)
    {
        int index = IndexOf(item);

        if (index < 0)
        {
            return false;
        }

        RemoveAt(index);

        return true;
    }

    public int IndexOf(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Аргумент равен null");
        }

        for (var i = 0; i < _size; i++)
        {
            if (item.Equals(_items[i]))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне границ списка!");
        }

        if (_size == _items.Length)
        {
            EnsureCapacity(_size + 1);
        }

        if (index < _size)
        {
            Array.Copy(_items, index, _items, index + 1, _size - index);
        }

        _items[index] = item;
        ++_size;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне границ списка!");
        }

        --_size;

        if (index < _size)
        {
            Array.Copy(_items, index + 1, _items, index, _size - index);
        }

        _items[_size] = default(T);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new SimpleArrayListEnumerator<T>(_items, _size);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(", ", _items.Select(x => x.ToString()).Take(_size));
    }
}