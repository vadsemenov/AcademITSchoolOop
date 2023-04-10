using System.Collections;
using System.Text;

namespace ListTask;

public class SingleLinkedList<T> : IEnumerable<T>
{
    private Node<T> _head;

    public int Count { get; private set; }

    public SingleLinkedList()
    {
    }

    public SingleLinkedList(T headNodeValue)
    {
        _head = new Node<T>(headNodeValue);
        Count++;
    }

    public void Add(T value)
    {
        InsertByIndex(Count, value);
    }

    private void CheckListIsEmpty()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("Список не содержит элементов.");
        }
    }

    private void CheckIndex(int index)
    {
        if (index < 0 && index < Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс должен быть больше или равен нулю и не больше размера списка. Текущее значение {index}");
        }
    }

    public T GetFirst()
    {
        CheckListIsEmpty();
        return _head.Value;
    }

    private Node<T> GetNodeByIndex(int index)
    {
        var currentNode = _head;

        for (var i = 1; i <= index; i++)
        {
            currentNode = currentNode.Next;
        }

        return currentNode;
    }

    public T GetByIndex(int index)
    {
        if (Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Список пуст, невозможно получить значение. Текущее значение индекса {index}");
        }

        CheckIndex(index);

        return GetNodeByIndex(index).Value;
    }

    public T SetByIndex(int index, T value)
    {
        if (Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Список пуст, невозможно присвоить значение. Текущее значение индекса {index}");
        }

        CheckIndex(index);

        var currentNode = GetNodeByIndex(index);

        var oldValue = currentNode.Value;

        currentNode.Value = value;

        return oldValue;
    }

    public T DeleteByIndex(int index)
    {
        if (Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Список пуст, невозможно удалить значение. Текущее значение индекса {index}");
        }

        CheckIndex(index);

        if (index == 0)
        {
            Count--;

            return DeleteFirst();
        }

        var previousNode = GetNodeByIndex(index - 1);
        var currentNode = previousNode.Next;

        var deletedValue = currentNode.Value;

        previousNode!.Next = currentNode.Next;

        Count--;

        return deletedValue;
    }

    public void AddFirst(T value)
    {
        _head = new Node<T>(value, _head);

        Count++;
    }

    public void InsertByIndex(int index, T value)
    {
        if (Count == 0)
        {
            _head = new Node<T>(value);

            Count++;

            return;
        }

        CheckIndex(index);

        if (index == 0)
        {
            AddFirst(value);
            return;
        }

        var previousNode = GetNodeByIndex(index - 1);
        previousNode.Next = new Node<T>(value, previousNode.Next);

        Count++;
    }

    public bool DeleteByValue(T value)
    {
        if (_head == null)
        {
            return false;
        }

        if (_head.Value.Equals(value))
        {
            DeleteFirst();

            return true;
        }

        var previousNode = _head;

        while (previousNode.Next != null)
        {
            var currentNode = previousNode.Next;

            if (currentNode.Value.Equals(value))
            {
                previousNode.Next = currentNode.Next;
                Count--;

                return true;
            }

            previousNode = currentNode;
        }

        return false;
    }

    public T DeleteFirst()
    {
        CheckListIsEmpty();

        var deletedValue = _head.Value;

        _head = _head.Next;

        Count--;

        return deletedValue;
    }

    public void Reverse()
    {
        if (Count < 2)
        {
            return;
        }

        var currentNode = _head;
        Node<T> previousNode = null;

        while (currentNode != null)
        {
            var tailNode = currentNode.Next;
            currentNode.Next = previousNode;

            previousNode = currentNode;
            currentNode = tailNode;
        }

        _head = previousNode;
    }

    public SingleLinkedList<T> Copy()
    {
        var newList = new SingleLinkedList<T>();

        if (Count == 0)
        {
            return newList;
        }

        newList._head = new Node<T>(_head.Value);

        var currentSourceNode = _head;

        var currentNode = newList._head;

        while (currentSourceNode.Next != null)
        {
            var nextNode = new Node<T>(currentSourceNode.Next.Value);

            currentNode.Next = nextNode;
            newList.Count++;

            currentNode = nextNode;

            currentSourceNode = currentSourceNode.Next;
        }

        newList.Count++;

        return newList;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = _head;

        while (currentNode != null)
        {
            yield return currentNode.Value;

            currentNode = currentNode.Next;
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
        stringBuilder.AppendJoin(", ", this);
        stringBuilder.Append("]");

        return stringBuilder.ToString();
    }
}