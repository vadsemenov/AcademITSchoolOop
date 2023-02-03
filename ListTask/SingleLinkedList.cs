using System;

namespace ListTask;

public class SingleLinkedList<T>
{
    private Node<T> _headNode;

    public SingleLinkedList()
    {
    }

    public SingleLinkedList(T headNodeValue)
    {
        _headNode = new Node<T>(headNodeValue);
    }

    public void Add(T value)
    {
        var node = new Node<T>(value);

        if (_headNode == null)
        {
            _headNode = node;
            return;
        }

        var currentNode = _headNode;

        while (currentNode.NextNode != null)
        {
            currentNode = currentNode.NextNode;
        }

        currentNode.NextNode = node;
    }

    public int GetSize()
    {
        var size = 0;

        if (_headNode == null)
        {
            return size;
        }

        size++;

        var currentNode = _headNode;

        while (currentNode.NextNode != null)
        {
            size++;
            currentNode = currentNode.NextNode;
        }

        return size;
    }

    public T GetHeadValue()
    {
        if (_headNode == null)
        {
            throw new ArgumentNullException(nameof(SingleLinkedList<T>), "List не содержит элементов.");
        }

        return _headNode.Value;
    }

    private Node<T> GetNodeByIndex(int index)
    {
        if (_headNode == null)
        {
            throw new ArgumentNullException(nameof(SingleLinkedList<T>), "List не содержит элементов.");
        }

        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Индекс должен быть больше или равен нулю. Текущее значение " + index);
        }

        var currentNode = _headNode;

        for (var i = 1; i <= index; i++)
        {
            currentNode = currentNode.NextNode ?? throw new ArgumentOutOfRangeException(nameof(index), "Размер списка меньше запрашиваемого индекса." + " Размер списка " + i + 1 + " элементов. Текущее значение индекса " + index);
        }

        return currentNode;
    }

    public T GetValueByIndex(int index)
    {
        var currentNode = GetNodeByIndex(index);

        return currentNode.Value;
    }

    public T SetValueByIndex(int index, T value)
    {
        var currentNode = GetNodeByIndex(index);

        T oldValue = currentNode.Value;

        currentNode.Value = value;

        return oldValue;
    }

    public T DeleteByIndex(int index)
    {
        if (_headNode == null)
        {
            throw new ArgumentNullException(nameof(index), "List не содержит элементов.");
        }

        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Индекс должен быть больше или равен нулю. Текущее значение " + index);
        }

        var parentNode = _headNode;
        var currentNode = _headNode;

        T oldValue;

        if (index == 0)
        {
            oldValue = _headNode.Value;
            _headNode = null;

            return oldValue;
        }

        for (var i = 1; i <= index; i++)
        {
            parentNode = currentNode;
            currentNode = currentNode.NextNode;

            if (currentNode == null)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Размер списка меньше индекса. Размер списка " + i + 1 + " элементов. Текущее значение индекса " + index);
            }
        }

        oldValue = currentNode.Value;

        parentNode.NextNode = currentNode.NextNode;

        return oldValue;
    }

    public void InsertHead(T value)
    {
        var tempNode = new Node<T>(_headNode, value);

        _headNode = tempNode;
    }

    public void InsertByIndex(int index, T value)
    {
        if (index == 0)
        {
            InsertHead(value);
            return;
        }

        var parentNode = GetNodeByIndex(index - 1);
        var currentNode = new Node<T>(parentNode.NextNode, value);
        parentNode.NextNode = currentNode;
    }

    public bool DeleteByValue(T value)
    {
        if (_headNode == null)
        {
            return false;
        }

        if (_headNode.Value.Equals(value))
        {
            _headNode = _headNode.NextNode;
            return true;
        }

        var parentNode = _headNode;

        while (parentNode.NextNode != null)
        {
            var currentNode = parentNode.NextNode;

            if (currentNode.Value.Equals(value))
            {
                parentNode.NextNode = currentNode.NextNode;
                return true;
            }

            parentNode = currentNode;
        }

        return false;
    }

    public T DeleteHead()
    {
        if (_headNode == null)
        {
            throw new ArgumentNullException(nameof(SingleLinkedList<T>), "List не содержит элементов.");
        }

        var deleteNodeValue = _headNode.Value;

        _headNode = _headNode.NextNode ?? throw new ArgumentNullException(nameof(SingleLinkedList<T>), "List содержит только 1 элемент.");

        return deleteNodeValue;
    }

    public void Reverse()
    {
        if (GetSize() < 2)
        {
            return;
        }

        var currentNode = _headNode;

        var tailNode = (Node<T>)currentNode.Clone();
        Node<T> previousTailNode = null;

        while (currentNode.NextNode != null)
        {
            previousTailNode = (Node<T>)currentNode.NextNode.Clone();

            previousTailNode.NextNode = tailNode;

            tailNode = previousTailNode;

            currentNode = currentNode.NextNode;
        }

        _headNode = previousTailNode;
    }

    public SingleLinkedList<T> Copy()
    {
        var newList = new SingleLinkedList<T>();

        if (GetSize() == 0)
        {
            return newList;
        }

        var newHeadNode = (Node<T>)_headNode.Clone();

        var currentSourceNode = _headNode;

        var currentNode = newHeadNode;

        while (currentSourceNode.NextNode != null)
        {
            var nextNode = (Node<T>)currentSourceNode.NextNode.Clone();

            currentNode.NextNode = nextNode;

            currentNode = nextNode;

            currentSourceNode = currentSourceNode.NextNode;
        }

        newList._headNode = newHeadNode;

        return newList;
    }
}