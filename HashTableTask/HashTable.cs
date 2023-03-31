using System.Collections;
using System.Text;

namespace HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private const int DefaultCapacity = 10;

        private readonly List<T>[] _lists;
        private int _modCount;

        public HashTable()
        {
            _lists = new List<T>[DefaultCapacity];
        }

        public HashTable(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"Размер таблицы должен быть более нуля, сейчас равен {capacity}!");
            }

            _lists = new List<T>[capacity];
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        private int GetIndex(T o)
        {
            if (o == null)
            {
                return 0;
            }

            return Math.Abs(o.GetHashCode() % _lists.Length);
        }

        public bool Contains(T item)
        {
            var index = GetIndex(item);

            return _lists[index] != null && _lists[index].Contains(item);
        }

        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            foreach (var list in _lists)
            {
                list?.Clear();
            }

            _modCount++;

            Count = 0;
        }

        public void Add(T item)
        {
            var index = GetIndex(item);

            if (_lists[index] == null)
            {
                _lists[index] = new List<T>();
            }

            Count++;
            _modCount++;

            _lists[index].Add(item);
        }

        public bool Remove(T item)
        {
            var index = GetIndex(item);

            if (_lists[index] != null && _lists[index].Remove(item))
            {
                _modCount++;
                Count--;

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var expectedModCount = _modCount;

            foreach (var list in _lists)
            {
                if (list != null)
                {
                    foreach (var value in list)
                    {
                        if (expectedModCount != _modCount)
                        {
                            throw new InvalidOperationException("Совершено изменение во время итерации!");
                        }

                        yield return value;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Массив равен null!");
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("Копирование в многомерные массивы не поддерживается!", nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Индекс должен быть >= 0!");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Размер массива не достаточен для копирования значений!", nameof(array));
            }

            CopyValues(array, arrayIndex);
        }

        private void CopyValues(T[] array, int arrayIndex)
        {
            var enumerator = GetEnumerator();

            while (enumerator.MoveNext())
            {
                array[arrayIndex++] = enumerator.Current;
            }

            enumerator.Dispose();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("[");

            foreach (var value in this)
            {
                stringBuilder.Append(value);
                stringBuilder.Append(", ");
            }

            if (Count > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
            }

            stringBuilder.Append("]");

            return stringBuilder.ToString();
        }
    }
}

