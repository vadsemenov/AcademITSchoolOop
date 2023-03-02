using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private const int DefaultCapacity = 10;
        private readonly List<T>[] _lists;
        private int _size;
        private static int _modCount;

        public HashTable()
        {
            _lists = new List<T>[DefaultCapacity];
        }

        public HashTable(int arrayLength)
        {
            if (arrayLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayLength),
                    "Размер таблицы должен быть более или равен нулю!");
            }

            _lists = new List<T>[arrayLength];
        }

        public int Count => _size;

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
            if (_size == 0)
            {
                return;
            }

            foreach (var list in _lists)
            {
                if (list != null)
                {
                    list.Clear();
                }
            }

            _modCount++;

            _size = 0;
        }

        public void Add(T item)
        {
            var index = GetIndex(item);

            if (_lists[index] == null)
            {
                _lists[index] = new List<T>();
            }

            _size++;
            _modCount++;

            _lists[index].Add(item);
        }

        public bool Remove(T item)
        {
            var index = GetIndex(item);

            if (_lists[index] != null && _lists[index].Remove(item))
            {
                _modCount++;
                _size--;

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new HashTableEnumerator(_modCount, _size, _lists);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex) => Array.Copy(_lists, 0, array, arrayIndex, _lists.Length);

        public override string ToString()
        {
            return new StringBuilder().Append("[ " + string.Join(" ", this) + " ]").ToString();
        }

        private class HashTableEnumerator : IEnumerator<T>
        {
            private readonly List<T>[] _lists;
            private readonly int _size;
            private readonly int _expectedModCount;

            private int _position = -1;
            private int _listIndex;
            private int _elementIndex = -1;

            public HashTableEnumerator(int modCount, int size, List<T>[] lists)
            {
                _expectedModCount = modCount;
                _size = size;
                _lists = lists;
            }

            public T Current
            {
                get
                {
                    if (_expectedModCount != _modCount)
                    {
                        throw new AccessViolationException("Совершено изменение во время итерации");
                    }

                    if (_position == -1 || _position >= _size)
                    {
                        throw new ArgumentException("Позиция перечеслителя вне диапазона!", nameof(_position));
                    }

                    return _lists[_listIndex][_elementIndex];
                }
            }

            public bool MoveNext()
            {
                if (_position < _size - 1)
                {
                    while (_lists[_listIndex] == null || _lists[_listIndex].Count - 1 == _elementIndex)
                    {
                        _listIndex++;
                        _elementIndex = -1;
                    }

                    _elementIndex++;
                    _position++;

                    return true;
                }

                return false;
            }

            object IEnumerator.Current => Current;

            public void Reset()
            {
                _position = -1;
            }

            public void Dispose()
            {

            }
        }
    }
}

