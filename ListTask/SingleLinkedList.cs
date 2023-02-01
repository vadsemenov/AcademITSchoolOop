using System;

namespace ListTask;

public class SingleLinkedList
{
    private Node _headNode;
    // private Node? _tailNode;

    public SingleLinkedList(int headNodeValue)
    {
        _headNode = new Node(headNodeValue);
        // _tailNode = _headNode;
    }

    public int GetSize()
    {
        int size = 0;

        if (_headNode == null)
        {
            return size;
        }

        size++;

        Node currentNode = _headNode;

        while (currentNode.NextNode != null)
        {
            size++;
            currentNode = currentNode.NextNode;
        }

        return size;
    }

    public int GetHeadValue()
    {
        if (_headNode == null)
        {
            throw new ArgumentNullException(nameof(SingleLinkedList),
                "List не содержит элементов.");
        }

        return _headNode.Value;
    }

    private Node GetNodeByIndex(int index)
    {
        if (_headNode == null)
        {
            throw new ArgumentNullException(nameof(SingleLinkedList),
                "List не содержит элементов.");
        }

        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index),
                "Индекс должен быть больше или равен нулю. Текущее значение " + index);
        }

        Node currentNode = _headNode;

        for (int i = 0; i <= index; i++)
        {
            if (currentNode.NextNode == null)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Размер списка меньше запрашиваемого индекса." +
                                                                     " Размер списка " + i + 1 +
                                                                     " элементов. Текущее значение индекса "
                                                                     + index);
            }

            currentNode = currentNode.NextNode;
        }

        return currentNode;
    }

    public int GetValueByIndex(int index)
    {
        Node currentNode = GetNodeByIndex(index);

        return currentNode.Value;
    }

    public int SetValueByIndex(int index, int value)
    {
        Node currentNode = GetNodeByIndex(index);

        int oldValue = currentNode.Value;

        currentNode.Value = value;

        return oldValue;
    }

    public int DeleteByIndex(int index)
    {
        if (_headNode == null)
        {
            throw new ArgumentNullException(nameof(index),
                "List не содержит элементов.");
        }

        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index),
                "Индекс должен быть больше или равен нулю. Текущее значение " + index);
        }

        Node parentNode = _headNode;
        Node currentNode = _headNode;

        int oldValue;

        if (index == 0)
        {
            oldValue = _headNode.Value;
            _headNode = null;

            return oldValue;
        }

        for (int i = 1; i <= index; i++)
        {
            parentNode = currentNode;
            currentNode = currentNode.NextNode;

            if (currentNode == null)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Размер списка меньше индекса." +
                                                                     " Размер списка " + i + 1 +
                                                                     " элементов. Текущее значение индекса "
                                                                     + index);
            }
        }

        oldValue = currentNode.Value;

        parentNode.NextNode = currentNode.NextNode;

        return oldValue;
    }

    public void InsertHead(int value)
    {
        Node tempNode = _headNode;

        _headNode = new Node(tempNode, value);
    }

    public void InsertByIndex(int index, int value)
    {
        if (index == 0)
        {
            InsertHead(value);
            return;
        }

        Node parentNode = GetNodeByIndex(index - 1);
        Node currentNode = new Node(parentNode.NextNode, value);
        parentNode.NextNode = currentNode;
    }

    public bool DeleteByValue(int value)
    {
        if (_headNode == null)
        {
            return false;
        }

        if (_headNode.Value == value)
        {
            _headNode = _headNode.NextNode;
            return true;
        }

        Node parentNode = _headNode;

        while (parentNode.NextNode != null)
        {
            Node currentNode = parentNode.NextNode;

            if (currentNode.Value == value)
            {
                parentNode.NextNode = currentNode.NextNode;
                return true;
            }

            parentNode = currentNode;
        }

        return false;
    }




}

public class Node
{
    public Node NextNode;

    public int Value { get; set; }

    public Node(int value) : this(null!, value)
    {
    }

    public Node(Node nextNode, int value)
    {
        NextNode = nextNode;
        Value = value;
    }

    public override string ToString()
    {
        return $"Значение узла равно {Value}";
    }
}