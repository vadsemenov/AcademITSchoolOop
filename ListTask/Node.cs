namespace ListTask;

public class Node<T> : ICloneable
{
    public Node<T> NextNode;

    public T Value { get; set; }

    public Node(T value) : this(null!, value)
    {
    }

    public Node(Node<T> nextNode, T value)
    {
        NextNode = nextNode;
        Value = value;
    }

    public override string ToString()
    {
        return $"Значение узла равно {Value}";
    }

    public object Clone()
    {
        return new Node<T>(Value);
    }
}