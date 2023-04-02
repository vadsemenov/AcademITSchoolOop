using System.Collections;
using System.Text;

namespace ArrayListTask;

public class SimpleArrayList<T> : IList<T>
{
    private const int DefaultCapacity = 4;
    private T[] _items;
    private int _modCount = 0;

    public SimpleArrayList() => _items = new T[DefaultCapacity];

    public SimpleArrayList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), $"Вместимость должна быть более или равна нулю, сейчас {capacity}!");
        }

        _items = new T[capacity];
    }

    public bool IsReadOnly => false;

    public int Capacity
    {
        get => _items.Length;
        set
        {
            if (value < Count)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Вместимость {value} меньше размера коллекции {Count}!");
            }

            if (value == _items.Length)
            {
                return;
            }

            if (value > 0)
            {
                Array.Resize(ref _items, value);
            }
            else
            {
                _items = Array.Empty<T>();
            }
        }
    }


    private void IncreaseCapacity()
    {
        long newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;

        if ((uint)newCapacity > int.MaxValue)
        {
            Capacity = int.MaxValue;
        }

        Capacity = (int)newCapacity;
    }

    public void TrimExcess()
    {
        if (Count >= (int)(_items.Length * 0.9))
        {
            return;
        }

        Capacity = Count;
    }

    private void CheckIndexForRead(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс {index}, должен быть от 0 до {Count} включительно!");
        }
    }

    private void CheckIndexForModify(int index)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс {index}, должен быть от 0 до {Count}!");
        }
    }

    public T this[int index]
    {
        get
        {
            CheckIndexForRead(index);

            return _items[index];
        }
        set
        {
            CheckIndexForModify(index);

            _items[index] = value;

            _modCount++;
        }
    }

    public int Count { get; private set; }

    public void Add(T item)
    {
        Insert(Count, item);
    }

    public void Clear()
    {
        Array.Clear(_items);
        Count = 0;

        _modCount++;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) != -1;
    }

    public void CopyTo(T[] array, int arrayIndex) => Array.Copy(_items, 0, array, arrayIndex, Count);

    public bool Remove(T item)
    {
        var index = IndexOf(item);

        if (index < 0)
        {
            return false;
        }

        RemoveAt(index);

        return true;
    }

    public int IndexOf(T item)
    {
        for (var i = 0; i < Count; i++)
        {
            if (_items[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        CheckIndexForModify(index);

        if (Count == _items.Length)
        {
            IncreaseCapacity();
        }

        if (index < Count)
        {
            Array.Copy(_items, index, _items, index + 1, Count - index);
        }

        _items[index] = item;
        ++Count;

        _modCount++;
    }

    public void RemoveAt(int index)
    {
        CheckIndexForModify(index);

        --Count;

        if (index < Count)
        {
            Array.Copy(_items, index + 1, _items, index, Count - index);
        }

        _items[Count] = default;

        _modCount++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var expectedModCount = _modCount;

        for (var i = 0; i < Count; i++)
        {
            if (expectedModCount != _modCount)
            {
                throw new InvalidOperationException("Совершено изменение во время итерации!");
            }

            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append("[");
        stringBuilder.AppendJoin(", ", _items.Take(Count));
        stringBuilder.Append("]");

        return stringBuilder.ToString();
    }
}