namespace ListTask;

internal class Node<T>
{
    public Node<T> Next { get; set; }

    public T Value { get; set; }

    public Node(T value) : this(value, null)
    {
    }

    public Node(T value, Node<T> next)
    {
        Value = value;
        Next = next;
    }
}