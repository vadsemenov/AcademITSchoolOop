using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableTask
{
    public class HashTable <T> : ICollection<T>
    {
        private const int DefaultCapacity = 4;
        private List<T>[] _lists;
        private static int _size;

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

        public int Count { get => _size; }

        public bool IsReadOnly { get; }

        private int GetIndex(Object o)
        {
            if (o == null)
            {
                return 0;
            }

            return Math.Abs(o.GetHashCode() % _lists.Length);
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

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

            _size = 0;
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (_lists[index] == null)
            {
                _lists[index] = new List<T>();
            }

            _size++;

            _lists[index].Add(item);
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (_lists[index] != null && _lists[index].Remove(item))
            {
                _size--;

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // private class HashTableEnumerator : IEnumerator<T>
        // {
        //     private int _position = -1;
        //
        //     public T Current {
        //         get
        //         {
        //             if (_position == -1 || _position >= _size)
        //             {
        //                 throw new ArgumentException("Позиция перечеслителя вне диапазона!", nameof(_position));
        //             }
        //
        //             while (_lists[listIndex] == null || lists[listIndex].size() - 1 == elementIndex)
        //             {
        //                 listIndex++;
        //                 elementIndex = -1;
        //             }
        //
        //             elementIndex++;
        //             count++;
        //
        //         }
        //     }
        //
        //     object IEnumerator.Current => Current;
        //
        //     public bool MoveNext()
        //     {
        //         throw new NotImplementedException();
        //     }
        //
        //     public void Reset()
        //     {
        //         _position = -1;
        //     }
        //
        //     public void Dispose()
        //     {
        //         
        //     }
        // }
        //


        public void CopyTo(T[] array, int arrayIndex) => Array.Copy(_lists, 0, array, arrayIndex, _lists.Length);


        public override string ToString()
        {
            return base.ToString();
        }
    }
}